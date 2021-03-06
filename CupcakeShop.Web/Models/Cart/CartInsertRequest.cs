using System.Collections.Generic;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.Web.Models.Cart
{
    public class CartInsertRequest
    {
        public int Id { get; set;}
        public int ClientId { get; set; }
        public IEnumerable<CupcakeCart>  CupcakeCarts { get; set;}
    }
}
