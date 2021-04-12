using System.Collections.Generic;
using System.Linq;

namespace CupcakeShop.Web.Entities
{
    public class Cart
    {
        public int Id { get; set;}
        public int ClientId { get; set; }
        public Client Client{ get; set;}
        public List<CupcakeCart> CupcakeCarts { get; set; }

        public Cart(int clientId)
        {
            ClientId = clientId;
            CupcakeCarts = new() { };
        }

        public void AddCupcake(int cupcakeId)
        {
            if (CupcakeCarts.Any(x => x.CupcakeId == cupcakeId))
            {
                CupcakeCart cupcakeCart = CupcakeCarts.First(x => x.CupcakeId == cupcakeId);
                cupcakeCart.IncreseQuantity();
                return;
            }

            CupcakeCart newCupcakeCart = new CupcakeCart(cupcakeId, Id);
            CupcakeCarts.Add(newCupcakeCart);
        }

        public void RemoveCucpake(int cupcakeId)
        {
            if (CupcakeCarts.Any(x => x.CupcakeId == cupcakeId))
            {
                CupcakeCart cupcakeCart = CupcakeCarts.First((x => x.CupcakeId == cupcakeId));
                cupcakeCart.DecreaseQuantity();
                cupcakeCart.Cupcake.IncreaseStock();
            }
        }
    }
}
