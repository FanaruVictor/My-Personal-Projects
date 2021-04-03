using CupcakeShop.Web.Entities;

namespace CupcakeShop.UnitTests.Builders
{
    public static class CandyBuilder
    {
        public static Candy GetCandy() => new ("Bombonele", "multiFlavour", 0, 0.5m, "multicolor",
            "stick");

    }
}
