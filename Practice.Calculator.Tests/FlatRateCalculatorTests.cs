using NUnit.Framework;
using Practice.Calculator.Services.Calculators;

namespace Practice.Calculator.Tests
{
    [TestFixture]
    public class FlatRateCalculatorTests
    {
        private FlatRateCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new FlatRateCalculator();
        }

        //Already Present Cases
        [TestCase(0, 0)]
        [TestCase(-100, 0)]
        [TestCase(100, 17)]
        [TestCase(1000000, 170000)]

        public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
        {

            // Act
            var result = await _calculator.CalculateAsync(income);

            // Assert
            Assert.AreEqual(expectedTax, result);
        }
    }
}
