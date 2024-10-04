using Microsoft.EntityFrameworkCore;
using SqlJoins_LinqC_;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(opts => opts.UseInMemoryDatabase("ShopDb"));

var app = builder.Build();

app.MapGet("/CustomersWithAddress", (ShopDbContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return new ShopRepo(dbContext).GetCustomersWithAddress();
});

app.MapGet("/Customers", (ShopDbContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return new ShopRepo(dbContext).GetCustomers();
});

app.MapGet("/Addresses", (ShopDbContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return new ShopRepo(dbContext).GetAddresses();
});

app.MapGet("/CustomersAndAddresses", (ShopDbContext dbContext) =>
{
    dbContext.Database.EnsureCreated();

    return new ShopRepo(dbContext).GetCustomersAndAddresses();
});

app.Run();
