using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachineBL;
using VendingMachineCLI;
using System.Collections.Generic;
using System.IO;
using System;

namespace VendingMachineTests
{
    [TestClass]
    public class VendingMachineTests
    {
        


        [TestMethod]
        public void StockMachineTest()
        {
            //Arrange
            var testDictionary = new Dictionary<string, Item>();
            testDictionary.Add("A1", new Chip(new string[] {"A1","Potato Crisps","3.05","Chip" }));

            var expected = testDictionary["A1"].ItemName;
            
            //Act
            string directory = Directory.GetCurrentDirectory();
            directory += @"..\..\..\..\..\etc";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            VendingMachine machine = new VendingMachine("Vendo - Matic 600", fullPath);
            machine.StockMachine();

            var actual = machine._inventory["A1"].ItemName;

            //Assert
            Assert.AreEqual(expected, actual, "Test Input was vendingmachine.csv");
        }

        [TestMethod]
        public void DispenseItemTest()
        {
            //Arrange
            var expected = 4;

            //Act
            string directory = Directory.GetCurrentDirectory();
            directory += @"..\..\..\..\..\etc";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            VendingMachine machine = new VendingMachine("Vendo - Matic 600", new string[] { "A1", "Potato Crisps", "3.05", "Chip" });

            machine.DispenseItem("A1");

            var actual = machine._inventory["A1"].Quantity;
            //Assert
            Assert.AreEqual(expected, actual, "Test input was A1 ");
        }

        [TestMethod]
        public void DispenseItemAtZeroQuantityTest()
        {
            //Arrange
            bool exceptionCaught = false;
            var expected = true;

            //Act
            string directory = Directory.GetCurrentDirectory();
            directory += @"..\..\..\..\..\etc";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            VendingMachine machine = new VendingMachine("Vendo - Matic 600", new string[] { "A1", "Potato Crisps", "3.05", "Chip" });

            var actual = exceptionCaught;

            try
            {
                machine.DispenseItem("A1");
                machine.DispenseItem("A1");
                machine.DispenseItem("A1");
                machine.DispenseItem("A1");
                machine.DispenseItem("A1");
                machine.DispenseItem("A1"); // This line should throw the execption
            }
            catch
            {
                exceptionCaught = true;
                actual = exceptionCaught;
            }

            //Assert
            Assert.AreEqual(expected, actual, "Test input 6 Deposit on a quantity of 5");
        }
    }
}
