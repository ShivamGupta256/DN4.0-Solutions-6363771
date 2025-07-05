using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

class Program
{
  static async Task Main()
  {
    using var context = new AppDbContext();
    if (!context.Categories.Any())
    {
      var electronics = new Category { Name = "Electronics" };
      var groceries = new Category { Name = "Groceries" };

      await context.Categories.AddRangeAsync(electronics, groceries);

      var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
      var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

      await context.Products.AddRangeAsync(product1, product2);
      await context.SaveChangesAsync();

      Console.WriteLine("Initial data inserted.");
    }
    
    var products = await context.Products.ToListAsync();
    foreach (var p in products)
      Console.WriteLine($"{p.Name} - ₹{p.Price}");

    var product = await context.Products.FindAsync(1);
    Console.WriteLine($"Found: {product?.Name}");

    var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
    Console.WriteLine($"Expensive: {expensive?.Name}");

  }
}
