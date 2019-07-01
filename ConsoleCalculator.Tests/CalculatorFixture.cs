using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckDoubleAddition()
        {
            // Arrange
                Double expected =0.02;
            //Act
                 Double actual = ConsoleCalculator.Calculator.Calculation(0.01,0.01,'+');
                 Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void CheckDoubleSubstraction()
        {
            // Arrange
            Double expected = -10;
            //Act
            Double actual = ConsoleCalculator.Calculator.Calculation(0, 10, '-');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckDoubleMultiplication()
        {
            // Arrange
            Double expected = 156.25;
            //Act
            Double actual = ConsoleCalculator.Calculator.Calculation(12.5, 12.5, '*');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckDoubleDivision()
        {
            // Arrange
            Double expected = 5;
            //Act
            Double actual = ConsoleCalculator.Calculator.Calculation(25.00, 5, '/');
            Assert.AreEqual(expected, actual);
        }

    }
}
