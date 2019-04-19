using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineBL;

namespace VendingMachineTests
{
    [TestClass]
    public class CustomerTests
    {
        private const decimal _testBalance = 10;
        private Customer _testClass = new Customer();


        [TestMethod]
        public void FeedMoneyPositiveTest()
        {
            //Arrange
            _testClass.ResetBalance(_testBalance);
            decimal expected = 20;
            //Act
            _testClass.FeedMoney(10);
            decimal actual = _testClass.Balance;
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was 10");
        }

        [TestMethod]
        public void FeedMoneyNegativeTest()
        {
            //Arrange
            _testClass.ResetBalance(_testBalance);
            bool exceptionCaught = false;
            var expected = true;

            //Act
            var actual = exceptionCaught;

            try
            {
                _testClass.FeedMoney(-10);
            }
            catch (Exception)
            {
                exceptionCaught = true;
                actual = exceptionCaught;
            }
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was -10");
        }

        [TestMethod]
        public void SpendMoneyTest()
        {
            //Arrange
            _testClass.ResetBalance(_testBalance);
            decimal expected = 5;
            //Act
            _testClass.SpendMoney(5);
            decimal actual = _testClass.Balance;
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was 10");

        }

        [TestMethod]
        public void ReturnChangeBalanceTest()
        {
            //Arrange
            _testClass.ResetBalance(_testBalance);
            decimal expected = 0;
            //Act
            _testClass.ReturnChange();
            decimal actual = _testClass.Balance;
            //Assert
            Assert.AreEqual(expected, actual, "The Balance should always be 0");

        }
        [TestMethod]
        public void ReturnChangeStringTest()
        {
            //Arrange
            _testClass.ResetBalance(_testBalance);
            string expected = "Quarters: 40 - Nickels: 0 - Dimes: 0";
            //Act
            string actual = _testClass.ReturnChange();
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was 10");

        }
    }
}
