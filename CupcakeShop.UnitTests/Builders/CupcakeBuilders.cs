using System;
using System.Collections.Generic;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.UnitTests.Builders
{
    public static class CupcakeBuilders
    {
        public static Cupcake GetCupcake() => new("Briosa cu vanilie", Cupcake.Cantity.Large, 1.99m,
            Cupcake.ProducerName.Inan, "Vanilie", new DateTime(2021,3,17),
            Cupcake.DoughType.WholemealFlour,  Cupcake.IcingType.BlackChocolate, Cupcake.GlutenType.Yes,3);
    }
}
