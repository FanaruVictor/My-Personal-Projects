using CupcakeShop.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CupcakeShop.Web.Configuration
{
    public static class ApiServices
    {
        private static readonly IConfiguration Configuration = Startup.StaticConfiguration;

        public static void AddAppDatabase(this IServiceCollection services)
        {
            var connectionString = Configuration["ConnectionString"];

            services.AddDbContext<CupcakeShopDbContext>(options =>
                options.UseSqlServer(connectionString,
                    sqlOptions => { sqlOptions.MigrationsAssembly(typeof(Startup).Assembly.ToString()); }));
        }
    }
}
