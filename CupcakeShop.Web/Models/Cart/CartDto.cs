using System.Collections.Generic;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.Web.Models.Cart
{
    public class CartDto
    {
        public int Id { get; set;}
        public int ClientId { get; set; }
        public Entities.Client Client{ get; set;}
        public List<CupcakeCart>  CupcakeCarts { get; set;}
    }
}
