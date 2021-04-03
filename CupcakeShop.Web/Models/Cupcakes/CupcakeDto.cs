using System;
using System.Collections.Generic;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.Web.Models.Cupcakes
{
    public class CupcakeDto
    {
        public int Id { get;  set; }
        public Cupcake.Cantity Weight { get;  set; }
        public decimal Price { get;  set; }
        public Cupcake.ProducerName Producer { get;  set; }
        public string Flavour { get;  set; }
        public DateTime Expiration { get;  set; }
        public Cupcake.IcingType Icing { get; set; }
        public IEnumerable<Entities.Candy> Candies { get; set; }
        public int Stock { get; set; }
        public Cupcake.DoughType Dough { get; set; }

        public string Name { get; set; }

    }
}
