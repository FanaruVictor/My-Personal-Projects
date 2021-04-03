using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace CupcakeShop.Web.Entities
{
    public class Client
    {
        public enum ClientType
        {
            Individual,
            Company
        }

        public int Id { get;private set; }
        public string FirstName { get;private set; }
        public string LastName { get;private set; }
        public string PhoneNumber { get;private set; }
        public string Email { get;private set; }
        public ClientType Type { get; private set; }
        public string Street { get;private set; }
        public int Block { get;private set; }
        public int Floor { get;private set; }
        public int Suit { get;private set; }


        public Cart Cart { get; set; }

        public List<Order> Order { get;private set; }


        public Client(string firstName, string lastName, string phoneNumber, string email, ClientType type, string street, int block,
            int floor, int suit)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Type = type;
            Street = street;
            Block = block;
            Floor = floor;
            Suit = suit;
        }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public string GetAddress()
        {
            return Street + " " + Block + " " + Floor + " " + Suit;
        }

        public void UpdateContact(string firstName, string lastName, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void UpdateAddress(string street, int block, int floor, int suit)
        {
            Street = street;
            Block = block;
            Floor = floor;
            Suit = suit;
        }

        public void UpdateType(ClientType type)
        {
            Type = type;
        }
    }
}
