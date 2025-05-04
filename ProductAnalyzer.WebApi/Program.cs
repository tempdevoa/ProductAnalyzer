using ProductAnalyzer.Domain.ProductAggregate;
using ProductAnalyzer.Gateways.ProductAggregate;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("ProductClient", client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<IProductQuery, ProductQuery>();
builder.Services.AddScoped<IProductGateway, ProductGateway>();
builder.Services.AddScoped<IProductClientFactory, ProductClientFactory>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
