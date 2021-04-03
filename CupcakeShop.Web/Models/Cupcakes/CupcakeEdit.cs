using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.Web.Models.Cupcakes
{
    public class CupcakeEdit
    {


        public string Name { get; set; }
        public List<BaseOption> WeightOptions { get; set; }
        public Cupcake.Cantity Weight { get; set; }

        [Range(0.0001, Double.MaxValue)]
        public decimal Price { get;  set; }
        public Cupcake.ProducerName Producer { get; set; }

        public string Flavour { get; set; }

        public Cupcake.DoughType Dough { get; set; }
        public List<BaseOption> DoughOptions { get; set; }
        public Cupcake.IcingType Icing { get; set; }
        public List<BaseOption> IcingOptions { get; set; }

        public Cupcake.GlutenType Gluten { get; set; }
        public int Stock { get; set; }

        public List<BaseOption> GlutenOptions { get; set; }

    }
}
