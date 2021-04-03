using CupcakeShop.UnitTests.Builders;
using FluentAssertions;
using Xunit;

namespace CupcakeShop.UnitTests.EntitiesTests
{
    public class CandyTests
    {
        [Fact]
        public void Constructor_is_assigning_needed_properties()
        {
            //Arrange+Act
            var candy = CandyBuilder.GetCandy();

            //Assert
            candy.CandyName.Should().Be("Bombonele");
            candy.CandyFlavour.Should().Be("multiFlavour");
            candy.Sugar.Should().Be(0);
            candy.Price.Should().Be(0.50m);
            candy.Color.Should().Be("multicolor");
            candy.Shape.Should().Be("stick");
        }

        [Fact]
        public void UpgradeProprieties_Succeded()
        {
            //Arrnage
            var candy = CandyBuilder.GetCandy();

            //Act
            candy.UpdateProprieties("Bombonici","Bluebarry",0.50m,"blue","ball");
            candy.CandyName.Should().Be("Bombonici");
            candy.CandyFlavour.Should().Be("Bluebarry");
            candy.Price.Should().Be(0.50m);
            candy.Color.Should().Be("blue");
            candy.Shape.Should().Be("ball");
        }
    }
}
