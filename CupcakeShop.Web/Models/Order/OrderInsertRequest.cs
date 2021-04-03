using System;
using System.Collections.Generic;
using CupcakeShop.Web.Models.Client;

namespace CupcakeShop.Web.Models.Order
{
    public class OrderInsertRequest
    {
        public DateTime DateOrder { get; private set; }
        public DateTime DateDelivery { get; set; }
        public Entities.Order.StatusType StatusOrder { get; set; }
        public int ClientId { get; set; }
        public ClientDto  ClientDto { get; set; }
        public bool Emergency { get; set; }
        public List<int> CupcakeIds { get; set; }
    }
}
