using CupcakeShop.Web.Entities;
using CupcakeShop.UnitTests.Builders;
using FluentAssertions;
using Xunit;

namespace CupcakeShop.UnitTests.EntitiesTests
{
    public class ClientTests
    {
        [Fact]
        public void Constructor_is_assigning_needed_properties()
        {
            // Arrange + Act
            var client = new Client("firstName", "lastName", "123", "email",
                Client.ClientType.Company, "street", 122, 133, 144);

            // Assert
            client.FirstName.Should().Be("firstName");
            client.LastName.Should().Be("lastName");
            client.PhoneNumber.Should().Be("123");
            client.Email.Should().Be("email");
            client.Type.Should().Be(Client.ClientType.Company);
            client.Street.Should().Be("street");
            client.Block.Should().Be(122);
            client.Floor.Should().Be(133);
            client.Suit.Should().Be(144);
        }

        [Fact]
        public void GetFullName_Is_FirstName_plus_LastName()
        {
            //Arrange
            var client = ClientBuilders.GetClient();
            var expected = "Ionel Popescu";

            //Act
            var actual = client.GetFullName();

            //Assert
            expected.Should().Be(actual);
        }

        [Fact]
        public void GetAddress_Is_Street_Block_Floor_and_Suit()
        {
            //Arrange
            var client = ClientBuilders.GetClient();
            var expected = "Stefan cel Mare 122 133 144";

            //Act
            var actual = client.GetAddress();

            //Assert
            expected.Should().Be(actual);
        }

        [Fact]
        public void Contact_is_updated()
        {
            //Arrange
            var client = ClientBuilders.GetClient();

            //Act
            client.UpdateContact("Gigi", "Ionescu", "1234", "asdf@gmail.com");

            // Assert
            client.FirstName.Should().Be("Gigi");
            client.LastName.Should().Be("Ionescu");
            client.PhoneNumber.Should().Be("1234");
            client.Email.Should().Be("asdf@gmail.com");
        }

        [Fact]
        public void Adress_is_updated()
        {
            //Arrange
            var client = ClientBuilders.GetClient();

            //Act
            client.UpdateAddress("Prelungirea Bradului", 1, 5, 13);

            //Assert
            client.Street.Should().Be("Prelungirea Bradului");
            client.Block.Should().Be(1);
            client.Floor.Should().Be(5);
            client.Suit.Should().Be(13);

        }
    }
}
