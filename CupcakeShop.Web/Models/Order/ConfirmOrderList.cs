using System.Collections.Generic;
using CupcakeShop.Web.Models.Client;
using CupcakeShop.Web.Models.Cupcakes;

namespace CupcakeShop.Web.Models.Order
{
    public class ConfirmOrderList
    {
        public OrderDto OrderDto { get; set; }
        public ClientDto ClientDto { get; set; }
        public List<CupcakeQuantityDto> CupcakeQuantityDto { get; set; }
       
    }
}
