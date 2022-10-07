using ApplicationLayer.Shared;
using Graphql.Auction;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer()
    .AddQueryType<AuctionQuery>();

// TODO This should not be singleton.
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();

