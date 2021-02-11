using System;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Theory]
        [InlineData('c')]
        //[InlineData('*')]
        public void IsValidKeyTest(char key)
        {
            //Arrange
            Calculator cal = new Calculator();

            //Act
            bool expectedValue = cal.IsValidKey(key);

            //Assert
            Assert.True(expectedValue);
        }

        [Fact]
        public void SimpleOperationTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '1', '0', '+', '2', '=' };
            string [] expectedOutputList = { "1", "10", "10", "2", "12"};
           
            for(int i=0;i<inputList.Length;i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }
           
        }

        [Fact]
        public void SKeyTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '1', '2', '+', '2', 'S','S','S','=' };
            string[] expectedOutputList = { "1", "12", "12", "2", "-2","2","-2","10"};

            for (int i = 0; i < inputList.Length; i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }

        }

        [Fact]
        public void ResultCalculationWithEqualAndChainOfMultipleOperatorsTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '1', '+', '2', '+', '3','+','='};
            string[] expectedOutputList = { "1", "1", "2", "3", "3","6","12"};

            for (int i = 0; i < inputList.Length; i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }

        }

        [Fact]
        public void CKeyTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '1', '+', '2', '+', 'C','2','3','S','s','x','1','0','x'};
            string[] expectedOutputList = { "1", "1", "2", "3", "0","2","23","-23","23","23","1","10","230"};

            for (int i = 0; i < inputList.Length; i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }

        }

        [Fact]
        public void MultipleZeroIgnoreBeforeDecimalPointTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '0', '0'};
            string[] expectedOutputList = { "0", "0"};

            for (int i = 0; i < inputList.Length; i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }

        }


        [Fact]
        public void MultipleDecimalPointsIgnoreTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '0', '.','.','1','.'};
            string[] expectedOutputList = { "0", "0.","0.","0.1","0.1"};

            for (int i = 0; i < inputList.Length; i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }

        }

        [Fact]
        public void MultipleZerosValidAfterDecimalPointTest()
        {
            //Arrange
            Calculator cal = new Calculator();
            char[] inputList = { '0', '.','0','0','1'};
            string[] expectedOutputList = { "0", "0.","0.0","0.00","0.001"};

            for (int i = 0; i < inputList.Length; i++)
            {
                //Act
                string actualResult = cal.Operate(inputList[i]);
                //Assert
                Assert.Equal(expectedOutputList[i], actualResult);

            }

        }
    }

}
