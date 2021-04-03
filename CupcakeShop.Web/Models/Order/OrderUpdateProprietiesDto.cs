using System;

namespace CupcakeShop.Web.Models.Order
{
    public class OrderUpdateProprietiesDto
    {
        public DateTime DateDelivery { get; set; }
        public Entities.Order.StatusType StatusOrder { get; set; }
        public bool Emergency { get; set; }
    }
}
