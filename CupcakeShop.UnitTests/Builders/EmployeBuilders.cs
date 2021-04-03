using CupcakeShop.Web.Entities;

namespace CupcakeShop.UnitTests.Builders
{
    public static class EmployeBuilders
    {
        public static Employee GetEmploye() => new("Alexandru", "Ciuc", 1200m, Employee.Post.Bartender,
            7m, 3m,1);
    }
}
