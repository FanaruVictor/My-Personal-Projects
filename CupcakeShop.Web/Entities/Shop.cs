using System.Collections.Generic;

namespace CupcakeShop.Web.Entities
{
    public class Shop
    {
        public int Id { get;  set; }
        public string Name { get; private  set; }

        public string Country { get; private set; }
        public string City { get; set; }
        public string Street { get; private set; }
        public int Block { get; private set; }
        public int Floor { get; private set; }
        public int Suit { get; private set; }
        public int Capital { get; private set; }
        public ICollection<Employee> Employes { get; private set; }
        public ICollection<Order> Orders { get; private set; }

        public Shop()
        {
        }

        public Shop(string name, string country,string city, string street, int block, int floor, int suit, int capital)
        {
            Name = name;
            Street = street;
            Block = block;
            Floor = floor;
            Suit = suit;
            Capital = capital;
        }

        public string  GetAdress()
        {
            return (Street + " " + Block + " " + Floor + " " + Suit);
        }

        public void UpdateProprieties(string name, string country, string city,string street, int block, int floor, int suit, int capital)
        {
            Name = name;
            Country = country;
            City = city;
            Street = street;
            Block = block;
            Floor = floor;
            Suit = suit;
            Capital = capital;
        }
    }
}
