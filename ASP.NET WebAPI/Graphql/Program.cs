using ApplicationLayer.Shared;
using Graphql.Auction;
using Graphql.Bid;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    // I like to have separate classes for each query. Inspiration: https://stackoverflow.com/a/73456530/163507
    .AddQueryType(q => q.Name("Query"))  
    .AddType<AuctionQuery>()
    .AddType<BidQuery>();

// TODO This should not be singleton.
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();

