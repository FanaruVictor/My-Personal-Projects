using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CupcakeShop.Web.Entities
{
    public class CupcakeCart
    {
        public int  CupcakeId { get; private set; }
        public Cupcake Cupcake { get; private set; }

        public int CartId { get; private set; }
        public Cart Cart { get; private set; }

        public int Quantity { get; private set; }

        public CupcakeCart(int cupcakeId, int cartId)
        {
            CupcakeId = cupcakeId;
            CartId = cartId;
            Quantity = 1;
        }

        public void IncreseQuantity()
        {
            Quantity ++;
        }
        public void DecreaseQuantity()
        {
            Quantity --;
        }

        public void UpdateQuantity(int number)
        {
            Quantity = number;
        }
    }


}
