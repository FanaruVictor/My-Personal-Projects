using CupcakeShop.Web.Entities;

namespace CupcakeShop.UnitTests.Builders
{
    public static class ShopBuilders
    {
        public static  Shop GetShop() => new("Briosica","Bacau","Bacau","Mioritei", 23, 0, 1, 35000);

    }
}
