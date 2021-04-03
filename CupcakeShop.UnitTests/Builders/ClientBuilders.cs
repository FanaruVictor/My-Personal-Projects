using CupcakeShop.Web.Entities;

namespace CupcakeShop.UnitTests.Builders
{
    public static class ClientBuilders
    {
        public static Client GetClient() => new ("Ionel", "Popescu", "123", "ionel@popescu.com",
            Client.ClientType.Company, "Stefan cel Mare", 122, 133, 144);
    }
}
