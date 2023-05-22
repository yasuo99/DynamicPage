using DynamicPage.Database;
using DynamicPage.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoDbContext>(builder => builder.UseSqlite(@"E:\src\DynamicPage\DynamicPage\Database\demo.db"));
// Add services to the container.
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/", async (httpContext) =>
{
    await httpContext.Response.WriteAsync("Hello");
});



app.Run();

static async Task ReCreateDatabaseAndFetchProductsAsync(ServiceProvider provider)
{
    await using var scope = provider.CreateAsyncScope();

    var dbContext = scope.ServiceProvider.GetRequiredService<DemoDbContext>();

    await dbContext.Database.EnsureDeletedAsync();
    await dbContext.Database.EnsureCreatedAsync();

    var id = new Guid("3CB4A79E-17DF-4F3F-8A5F-62561153E789");
    dbContext.Products.Add(new Product(id, "Product"));

    await dbContext.SaveChangesAsync();

    var products = await dbContext.Products.ToListAsync();
    Console.WriteLine(JsonSerializer.Serialize(products));
}
