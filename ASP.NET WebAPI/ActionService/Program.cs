using ApplicationLayer.Auction;
using ApplicationLayer.Bid;
using Infrastructure;
using ApplicationLayer.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ICommandHandler<CreateAuctionCommand, CreateAuctionCommandResponse>, CreateAuctionCommandHandler>();
builder.Services.AddTransient<ISyntaxValidator<CreateAuctionCommand>, CreateAuctionCommandSyntaxValidator>();

builder.Services.AddTransient<IQueryHandler<GetAuctionQuery, GetAuctionQueryResponse>, GetAuctionQueryHandler>();
builder.Services.AddTransient<ISyntaxValidator<GetAuctionQuery>, GetAuctionQuerySyntaxValidator>();

builder.Services.AddTransient<IQueryHandler<GetAuctionsQuery, GetAuctionsQueryResponse>, GetAuctionsQueryHandler>();
builder.Services.AddTransient<ISyntaxValidator<GetAuctionsQuery>, GetAuctionsQuerySyntaxValidator>();

builder.Services.AddTransient<ICommandHandler<CreateBidCommand, CreateBidCommandResponse>, CreateBidCommandHandler>();
builder.Services.AddTransient<ISyntaxValidator<CreateBidCommand>, CreateBidCommandSyntaxValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
