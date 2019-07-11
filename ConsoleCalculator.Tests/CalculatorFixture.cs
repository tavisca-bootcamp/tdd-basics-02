using System;
using System.Collections.Generic;
using Xunit;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator c = new Calculator();

        [Fact]
        public void Test1()
        {
            //Arrange
            List<char> sendKey = new List<char> { '1', '0', '+', '2', '=' };
            List<string> expected = new List<string> {"1", "10", "10", "2", "12" };
            List<string> actual = new List<string>();

            //Act
            foreach(char key in sendKey)
            {
                actual.Add(c.SendKeyPress(key));
            }

            //Assert
            for(int i=0;i<expected.Count;i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

        }

        [Fact]
        public void Test2()
        {
            //Arrange
            List<char> sendKey = new List<char> { '1', '0', '/', '0', '=' };
            List<string> expected = new List<string> { "1", "10", "10", "0", "-E-" };
            List<string> actual = new List<string>();

            //Act
            foreach (char key in sendKey)
            {
                actual.Add(c.SendKeyPress(key));
            }

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

        }

        [Fact]
        public void Test3()
        {
            //Arrange
            List<char> sendKey = new List<char> { '0', '0', '.', '.', '0', '0', '1' };
            List<string> expected = new List<string> { "0", "0", "0.", "0.", "0.0", "0.00", "0.001" };
            List<string> actual = new List<string>();

            //Act
            foreach (char key in sendKey)
            {
                actual.Add(c.SendKeyPress(key));
            }

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

        }

        [Fact]
        public void Test4()
        {
            //Arrange
            List<char> sendKey = new List<char> { '1', '2', '+', '2', 'S', 'S', 'S', '=' };
            List<string> expected = new List<string> { "1", "12", "12", "2", "-2", "2", "-2", "10" };
            List<string> actual = new List<string>();

            //Act
            foreach (char key in sendKey)
            {
                actual.Add(c.SendKeyPress(key));
            }

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

        }

        [Fact]
        public void Test5()
        {
            //Arrange
            List<char> sendKey = new List<char> { '1', '+', '2', '+', '3', '+', '=' };
            List<string> expected = new List<string> { "1", "1", "2", "3", "3", "6", "12" };
            List<string> actual = new List<string>();

            //Act
            foreach (char key in sendKey)
            {
                actual.Add(c.SendKeyPress(key));
            }

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

        }

        [Fact]
        public void Test6()
        {
            //Arrange
            List<char> sendKey = new List<char> { '1', '+', '2', '+', 'c' };
            List<string> expected = new List<string> { "1", "1", "2", "3", "0" };
            List<string> actual = new List<string>();

            //Act
            foreach (char key in sendKey)
            {
                actual.Add(c.SendKeyPress(key));
            }

            //Assert
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }

        }
    }
}
