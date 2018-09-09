﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using ProShop.Service;
using ProShop.Web.App_Start;
using ProShop.Web.Infrastructure.Extensions;
using ProShop.Web.Models;
using PrShop.Common;
using PrShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static ProShop.Service.productService;

namespace ProShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        IProductService _productService;
        IOrderService _orderService;
        ApplicationUserManager _userManager;
        
        public ShoppingCartController(IProductService productService,IOrderService orderService, ApplicationUserManager userManager)
        {
            _productService = productService;
            _orderService = orderService;
            _userManager = userManager;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            if(Session[CommonConstants.SessionCart] == null)
            Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            return View();
        }
        public ActionResult CheckOut()
        {
            if (Session[CommonConstants.SessionCart] == null)
            {
                return Redirect("/gio-hang.html");
               
            }
            return View();
        }
        public JsonResult GetUser()
        {
            if (Request.IsAuthenticated) { 
            var userId = User.Identity.GetUserId();
            var user = _userManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
        public JsonResult CreateOrder(string orderViewModel)
        {
            var order = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderNew = new Order();
            orderNew.UpdateOrder(order);

            if (Request.IsAuthenticated)
            {
                orderNew.CustomerId = User.Identity.GetUserId();
                orderNew.CreatedBy = User.Identity.GetUserName();
            }

            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach( var item in cart)
            {
                var detail = new OrderDetail();
                detail.ProductID = item.ProductId;
                detail.Quantitty = item.Quantity;
                orderDetails.Add(detail);
            }

            _orderService.Create(orderNew, orderDetails);
                return Json(new
                {
                    status = true
                });
           
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            if (Session[CommonConstants.SessionCart] == null)
                Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List < ShoppingCartViewModel >) Session[CommonConstants.SessionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if(cart == null) cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if (cart.Any(x=>x.ProductId == productId))
            {
                foreach(var item in cart) { 
                if(item.ProductId == productId)
                    {
                        item.Quantity += 1;
                    }
                }

            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = productId;
                var product = _productService.GetById(productId);
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            Session[CommonConstants.SessionCart] = cart;

            return Json(new {
                status = true
            });
        }
        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            foreach(var item in cartSession)
            {
                foreach(var jItem in cartViewModel)
                {
                    if(item.ProductId == jItem.ProductId)
                    {
                        item.Quantity = jItem.Quantity;
                    }
                }
            }

            Session[CommonConstants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult DeleteItem(int productId)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if(cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                Session[CommonConstants.SessionCart] = cartSession;

                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}