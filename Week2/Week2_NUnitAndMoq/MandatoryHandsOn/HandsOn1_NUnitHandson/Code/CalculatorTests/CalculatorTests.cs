using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator = null!;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
            Console.WriteLine("Setup completed before each test");
        }

        [Test]
        [TestCase(5, 3, 8, TestName = "Addition_PositiveNumbers")]
        [TestCase(-1, -1, -2, TestName = "Addition_NegativeNumbers")]
        [TestCase(0, 0, 0, TestName = "Addition_Zeroes")]
        [TestCase(2.5, 3.5, 6, TestName = "Addition_DecimalNumbers")]
        public void AdditionTest(double a, double b, double expected)
        {
            double actual = _calculator.Addition(a, b);
            
            Assert.That(actual, Is.EqualTo(expected),
                $"\nTest: {TestContext.CurrentContext.Test.Name}" +
                $"\nInput: {a} + {b}" +
                $"\nExpected: {expected}" +
                $"\nActual: {actual}");

            Console.WriteLine($"Test: {TestContext.CurrentContext.Test.Name}");
            Console.WriteLine($"Input: {a} + {b}");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Actual: {actual}");
        }

        [TearDown]
        public void Cleanup()
        {
            _calculator = null!;
            Console.WriteLine("Cleanup completed after each test\n");
        }
    }
}