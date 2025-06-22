using System;

namespace SingletonPatternExample
{
  public sealed class Logger
  {
    private static Logger _instance = null;
    private static readonly object _lock = new object();

    private Logger()
    {
      Console.WriteLine("Logger instance created");
    }

    public static Logger GetInstance()
    {
      if (_instance == null)
      {
        lock (_lock)
        {
          if (_instance == null)
          {
            _instance = new Logger();
          }
        }
      }
      return _instance;
    }

    public void Log(string message)
    {
      Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
    }
  }
  class Program
  {
    static void Main(string[] args)
    {

      Logger logger1 = Logger.GetInstance();
      logger1.Log("First log message");

      Logger logger2 = Logger.GetInstance();
      logger2.Log("Second log message");

      if (logger1 == logger2)
      {
        Console.WriteLine("Both logger instances are the same - Singleton works!");
      }
      else
      {
        Console.WriteLine("Different logger instances - Singleton failed!");
      }
    }
  }
}