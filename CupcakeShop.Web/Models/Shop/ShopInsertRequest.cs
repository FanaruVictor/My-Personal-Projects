namespace CupcakeShop.Web.Models.Shop
{
    public class ShopInsertRequest
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Block { get; set; }
        public int Floor { get; set; }
        public int Suit { get; set; }
        public int Capital { get; set; }

    }
}
