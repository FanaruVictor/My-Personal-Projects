namespace CupcakeShop.Web.Entities
{
    public class CupcakeOrder
    {
        public int CupcakeId { get; set; }
        public Cupcake Cupcake { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int  Quantity { get; set; }
        public CupcakeOrder(int cupcakeId, int orderId, int quantity)
        {
            CupcakeId = cupcakeId;
            OrderId = orderId;
            Quantity = quantity;
        }
    }
}
