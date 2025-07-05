using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<Product> Products { get; set; }
  public DbSet<Category> Categories { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer("Server=DESKTOP-8FKKR3P;Database=RetailDb;Trusted_Connection=True;Encrypt=False;");
  }
}
