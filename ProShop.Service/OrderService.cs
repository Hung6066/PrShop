using PrShop.Data.Infrastructure;
using PrShop.Data.Repositories;
using PrShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProShop.Service
{
    public interface IOrderService
    {
        bool Create(Order order, List<OrderDetail> orderDetails);
    }
    public class OrderService : IOrderService
    {
        IOrderRepository _oderRepository;
        IOrderDetailRepository _oderDetaiRepository;
        IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository oderRepository,IOrderDetailRepository orderDetailRepository, IUnitOfWork unitOfWork)
        {
            _oderRepository = oderRepository;
            _oderDetaiRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public bool Create(Order order, List<OrderDetail> orderDetails)
        {
            try { 
            _oderRepository.Add(order);
            _unitOfWork.Commit();

            foreach(var orderDetail in orderDetails)
            {
                orderDetail.OrderID = order.ID;
                _oderDetaiRepository.Add(orderDetail);
            }
            _unitOfWork.Commit();
            return true;
            }catch(Exception ex)
            {

                return false;
            }
        }
    }
}
