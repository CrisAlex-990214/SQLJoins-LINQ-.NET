using Microsoft.EntityFrameworkCore;
using SqlJoins_LinqC_;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(opts => opts.UseInMemoryDatabase("ShopDb"));

var app = builder.Build();

app.MapGet("/", (ShopDbContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
});


app.Run();
