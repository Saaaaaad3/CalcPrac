using NUnit.Framework;
using Practice.Calculator.Services.Calculators;

namespace Practice.Calculator.Tests
{
    [TestFixture]
    public class FlatValueCalculatorTests
    {
        private FlatValueCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new FlatValueCalculator();
        }

        //Already present cases
        [TestCase(-1, 0)]
        [TestCase(199999, 9999.95)]
        [TestCase(100, 5)]
        [TestCase(200000, 10000)]
        [TestCase(6000000, 10000)]

        public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
        {
            // Act
            var result = await _calculator.CalculateAsync(income);

            // Assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}
