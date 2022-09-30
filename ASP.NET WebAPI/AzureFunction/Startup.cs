using System;
using System.Xml.Serialization;
using Energinet.Business.MyService.FunctionApp;
using Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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