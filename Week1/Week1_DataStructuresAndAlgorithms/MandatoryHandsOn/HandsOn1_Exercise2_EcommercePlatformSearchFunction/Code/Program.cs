using System;

namespace EcommerceSearch
{
  public class Product
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
      ProductId = id;
      ProductName = name;
      Category = category;
    }
  }

  class Program
  {
    static int LinearSearch(Product[] products, string target)
    {
      for (int i = 0; i < products.Length; i++)
      {
        if (products[i].ProductName.Equals(target, StringComparison.OrdinalIgnoreCase))
        {
          return i;
        }
      }
      return -1;
    }

    static int BinarySearch(Product[] products, string target)
    {
      int left = 0;
      int right = products.Length - 1;

      while (left <= right)
      {
        int mid = left + (right - left) / 2;

        int comparison = string.Compare(products[mid].ProductName, target, StringComparison.OrdinalIgnoreCase);

        if (comparison == 0)
        {
          return mid;
        }
        else if (comparison < 0)
        {
          left = mid + 1;
        }
        else
        {
          right = mid - 1;
        }
      }

      return -1;
    }

    static void Main(string[] args)
    {
      Product[] products = {
                new Product(1, "Laptop", "Electronics"),
                new Product(2, "Smartphone", "Electronics"),
                new Product(3, "Headphones", "Electronics"),
                new Product(4, "Desk Chair", "Furniture"),
                new Product(5, "Coffee Mug", "Kitchen")
            };

      Product[] sortedProducts = new Product[products.Length];
      Array.Copy(products, sortedProducts, products.Length);
      Array.Sort(sortedProducts, (x, y) => string.Compare(x.ProductName, y.ProductName, StringComparison.OrdinalIgnoreCase));

      Console.WriteLine("E-commerce Platform Search Function");
      Console.WriteLine("Available products:");
      foreach (var product in products)
      {
        Console.WriteLine($"- {product.ProductName} ({product.Category})");
      }

      Console.Write("\nEnter product name to search (Linear Search): ");
      string searchTerm = Console.ReadLine();

      int linearResult = LinearSearch(products, searchTerm);
      if (linearResult != -1)
      {
        Console.WriteLine($"Found '{products[linearResult].ProductName}' at index {linearResult} (Linear Search)");
      }
      else
      {
        Console.WriteLine("Product not found (Linear Search)");
      }

      Console.Write("\nEnter product name to search (Binary Search): ");
      searchTerm = Console.ReadLine();

      int binaryResult = BinarySearch(sortedProducts, searchTerm);
      if (binaryResult != -1)
      {
        Console.WriteLine($"Found '{sortedProducts[binaryResult].ProductName}' at index {binaryResult} of sorted products array (Binary Search)");
      }
      else
      {
        Console.WriteLine("Product not found (Binary Search)");
      }

      // Complexity Analysis
      Console.WriteLine("\nTime Complexity Analysis:");
      Console.WriteLine("- Linear Search: O(n) in worst case (item at end or not found)");
      Console.WriteLine("- Binary Search: O(log n) requires sorted array");
      Console.WriteLine("\nRecommendation:");
      Console.WriteLine("- For small or unsorted datasets: Linear Search is simpler");
      Console.WriteLine("- For large, static datasets: Binary Search is more efficient after initial sort");
    }
  }
}