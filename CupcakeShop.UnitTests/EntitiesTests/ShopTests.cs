using CupcakeShop.UnitTests.Builders;
using FluentAssertions;
using Xunit;

namespace CupcakeShop.UnitTests.EntitiesTests
{
    public class ShopTests
    {
        [Fact]
        public void Constructor_is_asigning_needed_proprieties()
        {
            //Arrange+Act
            var shop = ShopBuilders.GetShop();

            //Assert
            shop.Name.Should().Be("Briosica");
            shop.Country.Should().Be("Bacau");
            shop.City.Should().Be("Bacau");
            shop.Street.Should().Be("Mioritei");
            shop.Block.Should().Be(23);
            shop.Floor.Should().Be(0);
            shop.Suit.Should().Be(1);
            shop.Capital.Should().Be(35000);
        }

        [Fact]
        public void GetAddress_Corectly()
        {
            //Arrange
            var shop = ShopBuilders.GetShop();
            var expected = "Mioritei 23 0 1";

            //Act
            var actual=shop.GetAdress();

            //Assert
            expected.Should().Be(actual);
        }

        [Fact]
        public void UpdateProprieties_Succeded()
        {
            //Arrange
            var shop = ShopBuilders.GetShop();

            //Act
            shop.UpdateProprieties("Btiosica","Bacau","Bacau","Banca Nationala", 75, 0, 1, 40000);

            //Assert
            shop.Name.Should().Be("Btiosica");
            shop.Country.Should().Be("Bacau");
            shop.City.Should().Be("Bacau");
            shop.Street.Should().Be("Banca Nationala");
            shop.Block.Should().Be(75);
            shop.Floor.Should().Be(0);
            shop.Suit.Should().Be(1);
            shop.Capital.Should().Be(40000);
        }
    }
}
