using System.Collections.Generic;
using CupcakeShop.Web.Models.Employee;

namespace CupcakeShop.Web.Models.Shop
{
    public class ShopList
    {
        public ShopDto shopDto { get; set; }
        public List<EmployeeDto> employeesList { get; set; }
    }
}
