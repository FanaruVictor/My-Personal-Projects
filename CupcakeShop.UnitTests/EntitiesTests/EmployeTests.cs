using CupcakeShop.Web.Entities;
using CupcakeShop.UnitTests.Builders;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xunit;

namespace CupcakeShop.UnitTests.EntitiesTests
{
    public class EmployeTests
    {
        [Fact]
        public void Constructor_is_assigning_needed_proprieties()
        {
            //Arrange+Act
            var employe = EmployeBuilders.GetEmploye();

            //Assert
            employe.FirstName.Should().Be("Alexandru");
            employe.LastName.Should().Be("Ciuc");
            employe.Salary.Should().Be(1200m);
            employe.Occupation.Should().Be(Employee.Post.Bartender);
            employe.HoursPerDay.Should().Be(7m);
            employe.Seniority.Should().Be(3m);
            employe.ShopId.Should().Be(1);
        }

        [Fact]
        public void UpdateProprieties_Succeded()
        {
            //Arrenge
            var employe = EmployeBuilders.GetEmploye();

            //Act
            employe.UpdateProprieties(1200m, Employee.Post.Waiter, 8, 4);
            employe.Salary.Should().Be(1200m);
            employe.Occupation.Should().Be(Employee.Post.Waiter);
            employe.HoursPerDay.Should().Be(8m);
            employe.Seniority.Should().Be(4m);
        }
    }
}
