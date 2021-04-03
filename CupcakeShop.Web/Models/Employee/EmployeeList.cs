using System.Collections.Generic;

namespace CupcakeShop.Web.Models.Employee
{
    public class EmployeeList
    {
        public List<EmployeeDto> Employees { get; set; }
        public int ShopId { get; set; }
    }
}
