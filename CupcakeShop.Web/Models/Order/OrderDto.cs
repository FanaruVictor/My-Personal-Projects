using System;
using System.Collections.Generic;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.Web.Models.Order
{
    public class OrderDto
    {
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public Entities.Order.StatusType StatusOrder { get; set; }
        public int ClientId { get; set; }
        public bool Emergency { get; set; }

    }
}
