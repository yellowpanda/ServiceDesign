using ApplicationLayer;
using ApplicationLayer.Auction;
using AzureFunction;
using Energinet.Business.MyService.FunctionApp;
using Infrastructure;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Energinet.Business.MyService.FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IJsonDeserializer, JsonDeserializer>();
            builder.Services.AddTransient<ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse>, CreateAuctionCommandHandler>();
            builder.Services.AddTransient<IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>, GetAuctionQueryHandler>();
        }

    }
}