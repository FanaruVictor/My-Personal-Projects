using System;
using CupcakeShop.Web.Entities;

namespace CupcakeShop.UnitTests.Builders
{
    public static class OrderBuilders
    {
        public static Order GetOrder() => new(new DateTime(2021, 3, 16),
            new DateTime(2021, 3, 17), 3, 0, true,5);
    }
}
