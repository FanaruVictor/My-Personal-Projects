namespace CupcakeShop.Web.Models.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Entities.Employee.Post Occupation { get; set; }
        public decimal HoursPerDay { get; set; }
        public decimal Seniority { get; set; }
        public int ShopId { get; set; }

    }
}
