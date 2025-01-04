using Moq;
using NUnit.Framework;
using Practice.Calculator.Data.Models;
using Practice.Calculator.Services.Abstractions;
using Practice.Calculator.Services.Calculators;

namespace Practice.Calculator.Tests
{
    [TestFixture]
    internal class ProgressiveCalculatorTests
    {
        private Mock<ICalculatorSettingsService> _mockSettingsService;
        private ProgressiveCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _mockSettingsService = new Mock<ICalculatorSettingsService>();

            // Mock the service to return predefined tax brackets
            _mockSettingsService
                .Setup(s => s.GetSettingsAsync(CalculatorType.Progressive))
                .ReturnsAsync(new List<CalculatorSetting>
                {
                    new CalculatorSetting { From = 0, To = 8350, Rate = 10 },
                    new CalculatorSetting { From = 8350, To = 33950, Rate = 15 },
                    new CalculatorSetting { From = 33950, To = 82250, Rate = 25 },
                    new CalculatorSetting { From = 82250, To = 171550, Rate = 28 },
                    new CalculatorSetting { From = 171550, To = 372950, Rate = 33 },
                    new CalculatorSetting { From = 372950, To = null, Rate = 35 },
                });

            _calculator = new ProgressiveCalculator(_mockSettingsService.Object);
        }

        //Already Present Test Cases
        [TestCase(-1, 0)]
        [TestCase(50, 5)]
        [TestCase(8350, 835)]
        [TestCase(8351, 835.15)]
        [TestCase(33951, 4675.25)]
        [TestCase(82251, 16750.28)]
        [TestCase(171550, 41734)]
        [TestCase(999999, 327683.15)]

        public async Task CalculateAsync_Should_Return_Correct_Tax(decimal income, decimal expectedTax)
        {
            // Act
            var actualTax = await _calculator.CalculateAsync(income);

            // Assert
            Assert.AreEqual(expectedTax, actualTax);
        }
    }
}
