using System;

namespace FinancialForecasting
{
  class Program
  {
    static double ForecastValue(double currentValue, double growthRate, int years)
    {
      if (years <= 0)
      {
        return currentValue;
      }
      double nextValue = currentValue * (1 + growthRate / 100);
      return ForecastValue(nextValue, growthRate, years - 1);
    }
    static double ForecastValueMemoized(double currentValue, double growthRate, int years, double[] memo = null)
    {
      if (memo == null)
      {
        memo = new double[years + 1];
        memo[0] = currentValue;
      }

      if (memo[years] != 0)
      {
        return memo[years];
      }

      double prevValue = ForecastValueMemoized(currentValue, growthRate, years - 1, memo);
      memo[years] = prevValue * (1 + growthRate / 100);
      return memo[years];
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Financial Forecasting Tool");
      Console.WriteLine("--------------------------");

      Console.Write("Enter current value: ");
      double currentValue = double.Parse(Console.ReadLine());

      Console.Write("Enter annual growth rate (%): ");
      double growthRate = double.Parse(Console.ReadLine());

      Console.Write("Enter number of years to forecast: ");
      int years = int.Parse(Console.ReadLine());

      Console.WriteLine("\nBasic Recursive Forecast:");
      for (int i = 0; i <= years; i++)
      {
        double forecast = ForecastValue(currentValue, growthRate, i);
        Console.WriteLine($"Year {i}: {forecast:C2}");
      }

      Console.WriteLine("\nOptimized Memoized Forecast:");
      for (int i = 0; i <= years; i++)
      {
        double forecast = ForecastValueMemoized(currentValue, growthRate, i);
        Console.WriteLine($"Year {i}: {forecast:C2}");
      }

      // Complexity Analysis
      Console.WriteLine("\nAlgorithm Analysis:");
      Console.WriteLine("- Basic Recursive: O(2^n) time complexity due to repeated calculations");
      Console.WriteLine("- Memoized Version: O(n) time and space complexity by storing results");
      Console.WriteLine("\nRecommendation:");
      Console.WriteLine("- For small values of years (<20): Basic recursion is acceptable");
      Console.WriteLine("- For larger values: Use memoization or iterative approach");
    }
  }
}