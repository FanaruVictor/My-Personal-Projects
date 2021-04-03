namespace CupcakeShop.Web.Models.Candy
{
    public class CandyInsertRequest
    {
        public string CandyName { get; set; }
        public string CandyFlavour { get; set; }
        public int Suger { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Shape { get; set; }
    }
}
