namespace CupcakeShop.Web.Models.Client
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Entities.Client.ClientType Type { get; private set; }
        public string Street { get; set; }
        public int Block { get; set; }
        public int Floor { get; set; }
        public int Suit { get; set; }
    }
}
