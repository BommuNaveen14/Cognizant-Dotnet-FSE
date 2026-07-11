using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }

        [TestCase(10, 20, 30)]
        [TestCase(5, 7, 12)]
        [TestCase(-5, 10, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, -5, -10)]
        public void Add_Test(int a, int b, int expected)
        {
            int actual = calculator.Add(a, b);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}