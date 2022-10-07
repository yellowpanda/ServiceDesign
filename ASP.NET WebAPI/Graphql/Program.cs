using ApplicationLayer.Shared;
using Graphql;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    .AddQueryType<Query>();

// TODO This should not be singleton.
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting().UseEndpoints(endpoints => endpoints.MapGraphQL());

app.Run();

