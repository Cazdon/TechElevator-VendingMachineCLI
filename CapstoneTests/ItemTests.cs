using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using VendingMachineBL;

namespace VendingMachineTests
{
    [TestClass]
    public class ItemTests
    {
        private Item _testChip = new Chip(new string[] {"A1", "Potato Crisps", "3.05", "Chip" });
        private Item _testDrink = new Drink(new string[] { "C1", "Cola", "1.25", "Drink" });
        private Item _testGum = new Gum(new string[] { "D1", "U-Chews", "0.85", "Gum" });
        private Item _testCandy = new Candy(new string[] { "B1", "Moonpie", "1.80", "Candy" });

        [TestMethod]
        public void MakeChipSoundTest()
        {
            //Arrange
            var expected = "Crunch Crunch, Yum!";
            //Act
            var actual = _testChip.Sound();
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was a Chip Object");
        }

        [TestMethod]
        public void MakeDrinkSoundTest()
        {
            //Arrange
            var expected = "Glug Glug, Yum!";
            //Act
            var actual = _testDrink.Sound();
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was a Drink Object");
        }

        [TestMethod]
        public void MakeGumSoundTest()
        {
            //Arrange
            var expected = "Chew Chew, Yum!";
            //Act
            var actual = _testGum.Sound();
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was a Gum Object");
        }

        [TestMethod]
        public void MakeCandySoundTest()
        {
            //Arrange
            var expected = "Munch Munch, Yum!";
            //Act
            var actual = _testCandy.Sound();
            //Assert
            Assert.AreEqual(expected, actual, "Test Input was a Candy Object");
        }
    }
}
