using System;
using CupcakeShop.UnitTests.Builders;
using CupcakeShop.Web.Entities;
using FluentAssertions;
using Xunit;

namespace CupcakeShop.UnitTests.EntitiesTests
{
    public class CupcakeTests
    {
        [Fact]
        public void Constructor_is_assigning_needed_properties()
        {
            //Arrange+Act
            var cupcake = CupcakeBuilders.GetCupcake();

            //Assert
            cupcake.Name.Should().Be("Briosa cu vanilie");
            cupcake.Weight.Should().Be(Cupcake.Cantity.Large);
            cupcake.Price.Should().Be(1.99m);
            cupcake.Producer.Should().Be(Cupcake.ProducerName.Inan);
            cupcake.Expiration.Should().Be(new DateTime(2021, 3, 17));
            cupcake.Dough.Should().Be(Cupcake.DoughType.WholemealFlour);
            cupcake.Icing.Should().Be(Cupcake.IcingType.BlackChocolate);
            cupcake.Flavour.Should().Be("Vanilie");
            cupcake.Gluten.Should().Be(Cupcake.GlutenType.Yes);
            cupcake.Stock.Should().Be(3);
        }

        [Fact]
        public void UpdateProprieties_Succeded()
        {
            //Arrange
            var cupcake = CupcakeBuilders.GetCupcake();

            //Act
            cupcake.UpdateProprieties("Briosa cu ciocolata", Cupcake.Cantity.Medium, Cupcake.ProducerName.Miraleb,
                Cupcake.DoughType.ProteicFlour, Cupcake.GlutenType.No,
                2.99M, "Chocolate", Cupcake.IcingType.BlackChocolate, 4);

            //Assert
            cupcake.Name.Should().Be("Briosa cu ciocolata");
            cupcake.Weight.Should().Be(Cupcake.Cantity.Medium);
            cupcake.Producer.Should().Be(Cupcake.ProducerName.Miraleb);
            cupcake.Dough.Should().Be(Cupcake.DoughType.ProteicFlour);
            cupcake.Gluten.Should().Be(Cupcake.GlutenType.No);
            cupcake.Price.Should().Be(2.99M);
            cupcake.Icing.Should().Be(Cupcake.IcingType.BlackChocolate);
            cupcake.Flavour.Should().Be("Chocolate");
            cupcake.Stock.Should().Be(4);
        }
    }
}
