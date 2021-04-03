using CupcakeShop.UnitTests.Builders;
using Xunit;

namespace CupcakeShop.UnitTests.EntitiesTests
{
    public class OrderTests
    {
        [Fact]
        public void Constructor_is_assigning_needed_properties()
        {
            var order = OrderBuilders.GetOrder();
        }
    }
}
