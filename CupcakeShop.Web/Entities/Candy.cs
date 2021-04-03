using System.Collections.Generic;

namespace CupcakeShop.Web.Entities
{
    public class Candy
    {
        public int Id { get;private set; }
        public string CandyName { get;private set; }
        public string CandyFlavour { get;private set; }
        public int Sugar { get;private set; }
        public decimal Price { get;private set; }
        public string Color { get;private set; }
        public string Shape { get;private set; }
        public IEnumerable<CupcakeCandy> CupcakeCandies { get; set; }


        public Candy( string candyName, string candyFlavour, int sugar, decimal price, string color, string shape)
        {
            CandyName = candyName;
            CandyFlavour = candyFlavour;
            Sugar = sugar;
            Price = price;
            Color = color;
            Shape = shape;
        }

        public void UpdateProprieties(string candyName, string candyFlavour, decimal price, string color, string shape)
        {
            CandyName = candyName;
            CandyFlavour = candyFlavour;
            Price = price;
            Color = color;
            Shape = shape;
        }
    }
}
