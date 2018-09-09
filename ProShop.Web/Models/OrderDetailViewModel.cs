using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProShop.Web.Models
{
    public class OrderDetailViewModel
    {
        public int OrderID { get; set; }
        public int productID { get; set; }
        public int Quantity { get; set; }
    }
}