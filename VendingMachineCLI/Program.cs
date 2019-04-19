using System;
using VendingMachineBL;
using System.IO;

namespace VendingMachineCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = Directory.GetCurrentDirectory();
            directory += @"..\..\..\..\..\etc";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            VendingMachine machine = new VendingMachine("Vendo - Matic 600", fullPath);
            machine.StockMachine();
            machine.InitializeUnitsSold();
            VendingMachineCLI machineCLI = new VendingMachineCLI(machine);
            
            machineCLI.MainMenu();
        }
    }
}
