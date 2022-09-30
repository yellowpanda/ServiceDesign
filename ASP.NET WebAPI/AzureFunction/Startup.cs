using Energinet.Business.MyService.FunctionApp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Energinet.Business.MyService.FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            //builder.Services.AddDbContext<UnitOfWork.MyDbContext>(options =>
            //    options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=true;Database=Auction")
            //    );

            //builder.Services.AddDbContext<UnitOfWork.MyDbContext>(
            //    options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=true;Database=Auction")
            //    );
        }

    }
}