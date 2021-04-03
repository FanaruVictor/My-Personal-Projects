using System.Collections.Generic;
using CupcakeShop.Web.Models.Client;
using CupcakeShop.Web.Models.Cupcakes;

namespace CupcakeShop.Web.Models.Order
{
    public class ConfirmOrderList
    {
        public ClientDto ClientDto { get; set; }
        public List<CupcakeDto> CupcakeDtos { get; set; }
        public OrderDto OrderDto { get; set; }
    }
}
