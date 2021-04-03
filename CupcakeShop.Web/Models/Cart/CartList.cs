using System.Collections;
using System.Collections.Generic;
using CupcakeShop.Web.Models.Cupcakes;

namespace CupcakeShop.Web.Models.Cart
{
    public class CartList
    {
        public List<CupcakeQuantityDto> CupcakeDtos { get; set; }
        public CartDto CartDto { get; set; }

    }


}
