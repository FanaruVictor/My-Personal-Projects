using System;
using System.Collections.Generic;

namespace CupcakeShop.Web.Entities
{
    public class Cupcake
    {
        public enum ProducerName
        {
            Inan,
            Story,
            Miraleb
        }

        public enum Cantity
        {
            Medium,
            Small,
            Large
        }

        public enum DoughType
        {
            WholemealFlour,
            ProteicFlour,
            NormalFlour
        }

        public enum IcingType
        {
            BlackChocolate,
            MilkChocolate,
            WhiteChocolate,
            Caramel,
            BurnSugar
        }

        public enum GlutenType
        {
            Yes,
            No
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public Cantity Weight { get; private set; }
        public decimal Price { get; private set; }
        public ProducerName Producer { get; private set; }
        public string Flavour { get; private set; }
        public DateTime Expiration { get; private set; }
        public IEnumerable<CupcakeOrder> OrderCupcakes { get;private set; }
        public List<CupcakeCart>  CupcakeCarts { get; set; }
        public DoughType Dough { get; private set; }
        public IcingType Icing { get; private set; }
        public IEnumerable<Candy> Candies { get;private set; }
        public GlutenType Gluten { get;private set; }
        public int Stock { get; set; }
        public List<CupcakeCandy> CupcakeCandies { get;private set; }


        public Cupcake()
        {
        }

        public Cupcake(string name, Cantity weight, decimal price, ProducerName producer, string flavour, DateTime expiration,
            DoughType dough, IcingType icing, GlutenType gluten,int stock)
        {
            Name = name;
            Weight = weight;
            Price = price;
            Producer = producer;
            Flavour = flavour;
            Expiration = expiration;
            Dough = dough;
            Icing = icing;
            Gluten = gluten;
            Stock = stock;
        }

        public void UpdateProprieties(string name, Cantity weight, ProducerName producer, DoughType dough, GlutenType gluten,
            decimal price, string flavour, IcingType icing,int stock)
        {
            Price = price;
            Producer = producer;
            Weight = weight;
            Flavour = flavour;
            Dough = dough;
            Icing = icing;
            Gluten = gluten;
            Name = name;
            Stock = stock;
        }

        public void DecreaseStock()
        {
            Stock--;
        }
        public void IncreaseStock()
        {
            Stock++;
        }

        public void RestoreStock(int number)
        {
            Stock += number;
        }
    }
}
