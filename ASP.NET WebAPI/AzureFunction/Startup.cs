using ApplicationLayer.Auction;
using ApplicationLayer.Shared;
using AzureFunction.Shared;
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
            builder.Services.AddTransient<IJsonDeserializer, JsonDeserializer>();
            
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            builder.Services.AddTransient<ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse>, CreateAuctionCommandHandler>();
            builder.Services.AddTransient<ISyntaxValidator<CreateAuctionCommand>, CreateAuctionCommandSyntaxValidator>();

            builder.Services.AddTransient<IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>, GetAuctionQueryHandler>();
            builder.Services.AddTransient<ISyntaxValidator<GetAuctionQuery>, GetAuctionQuerySyntaxValidator>();

            builder.Services.AddTransient<IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse>, GetAuctionsQueryHandler>();
            builder.Services.AddTransient<ISyntaxValidator<GetAuctionsQuery>, GetAuctionsQuerySyntaxValidator>();
        }

    }
}