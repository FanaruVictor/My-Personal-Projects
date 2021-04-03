namespace CupcakeShop.Web.Entities
{
    public class CupcakeCandy
    {
        public int CupcakeId { get; set; }
        public Cupcake Cupcake { get; set; }

        public int CandyId { get; set; }
        public Candy Candy { get; set; }

        public CupcakeCandy(int cupcakeId,int candyId)
        {
            CupcakeId = cupcakeId;
            CandyId = candyId;
        }
    }
}
