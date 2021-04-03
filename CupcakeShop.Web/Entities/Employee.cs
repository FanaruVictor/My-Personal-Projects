namespace CupcakeShop.Web.Entities
{
    public class Employee
    {
        public enum Post
        {
            Manager,
            Chef,
            ChefAid,
            Waiter,
            Bartender
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public decimal Salary { get; private set; }
        public Post Occupation { get; private set; }
        public decimal HoursPerDay { get; private set; }
        public decimal Seniority { get; private set; }
        public int ShopId { get; private set; }
        public Shop Shop { get; private set; }

        public Employee(string firstName, string lastName, decimal salary, Post occupation, decimal hoursPerDay,
            decimal seniority, int shopId)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Occupation = occupation;
            HoursPerDay = hoursPerDay;
            Seniority = seniority;
            ShopId = shopId;
        }

        public string GetFullName()
        {
            return FirstName + LastName;
        }

        public decimal GetHourPerWeek()
        {
            return 7 * HoursPerDay;
        }

        public void UpdateProprieties(decimal salary, Post occupation, decimal hoursPerDay, decimal seniority)
        {
            Salary = salary;
            Occupation = occupation;
            HoursPerDay = hoursPerDay;
            Seniority = seniority;
        }
    }
}
