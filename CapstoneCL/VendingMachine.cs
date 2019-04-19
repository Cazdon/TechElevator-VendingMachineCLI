using System;
using System.IO;
using System.Collections.Generic;

namespace VendingMachineBL
{
    public class VendingMachine
    {
        #region Member Variables
        public Dictionary<string, Item> _inventory = new Dictionary<string, Item>();
        #endregion

        #region Properties
        public string MachineName { get; }
        public string InputFilePath { get; }
        public string LogFilePath { get; }
        public string SalesReportFilePath { get; }


        private decimal TotalSales { get; }
        #endregion

        #region Constructor
        public VendingMachine(string machineName, string inputFilePath)
        {
            string directory = Directory.GetCurrentDirectory();
            directory += @"..\..\..\..\..\etc";
            string logFileName = "Log.txt";
            string salesReportFileName = "SalesReport.txt";
            MachineName = machineName;
            InputFilePath = inputFilePath;
            LogFilePath = Path.Combine(directory, logFileName);
            SalesReportFilePath = Path.Combine(directory, salesReportFileName);
        }
        public VendingMachine(string machineName, string[] textArray)
        {
            if (textArray[3] == "Chip")
            {
                _inventory.Add(textArray[0], new Chip(textArray));
            }
            else if (textArray[3] == "Drink")
            {
                _inventory.Add(textArray[0], new Drink(textArray));
            }
            else if (textArray[3] == "Candy")
            {
                _inventory.Add(textArray[0], new Candy(textArray));
            }
            else if (textArray[3] == "Gum")
            {
                _inventory.Add(textArray[0], new Gum(textArray));
            }
            MachineName = machineName;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Calls and decodes the Input file given in the Constructor, and stocks the Machine with Items.
        /// </summary>
        public void StockMachine()
        {
            string text = "";
            using (StreamReader sr = new StreamReader(InputFilePath))
            {
                while ((text = sr.ReadLine()) != null)
                {
                    string[] textArray = text.Split('|');
                    if (textArray[3] == "Chip")
                    {
                        _inventory.Add(textArray[0],new Chip(textArray));
                    }
                    else if(textArray[3] == "Drink")
                    {
                        _inventory.Add(textArray[0],new Drink(textArray));
                    }
                    else if (textArray[3] == "Candy")
                    {
                        _inventory.Add(textArray[0], new Candy(textArray));
                    }
                    else if (textArray[3] == "Gum")
                    {
                        _inventory.Add(textArray[0], new Gum(textArray));
                    }
                }
            }
            
        }

        /// <summary>
        /// Subtract the passed item's quantity by one
        /// </summary>
        public void DispenseItem(string selectionKey)
        {
           var item = _inventory[selectionKey];
            if (item.Quantity > 0)
            {
                item.Quantity -= 1;
                item.UnitsSold += 1;
            }
            else
            {
                throw new Exception("Sold Out! the item you selected needs to be restocked");
            }
        }

        /// <summary>
        /// Write to the Log File
        /// </summary>
        public void AuditLogReport(string actionType, decimal balance1, decimal balance2)
        {
            using (StreamWriter sw = new StreamWriter(LogFilePath, true))
            {
                sw.WriteLine($"{DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt")} {actionType}: {balance1.ToString("C").PadLeft(20, ' ').PadRight(10, ' ')}   {balance2.ToString("C").PadRight(20,' ')}");
            }
        }

        /// <summary>
        /// Updates the total sales property and writes to the sales file
        /// </summary>
        public void UpdateSalesReport()
        {         
            using (StreamWriter sw = new StreamWriter(SalesReportFilePath, false))
            {
                decimal totalSales = 0;
                foreach(var item in _inventory)
                {
                    sw.WriteLine($"{item.Value.ItemName}|{item.Value.UnitsSold}");
                    totalSales+= item.Value.Price * item.Value.UnitsSold;
                }
                sw.WriteLine();
                sw.WriteLine($"**TOTAL SALES** ${totalSales}");
            }
        }

        /// <summary>
        /// Returns the Sales Report
        /// </summary>
        public string ReadSalesReport()
        {
            string salesReport = "";
            using (StreamReader sr = new StreamReader(SalesReportFilePath))
            {
                while (!sr.EndOfStream)
                {
                    salesReport = sr.ReadToEnd();
                }
            }
            return salesReport;
        }
        public void InitializeUnitsSold()
        {
            try
            {
                using (StreamReader sr = new StreamReader(SalesReportFilePath))
                {
                    string[] textArray = new string[2];
                    string line = sr.ReadLine();

                    while (line != "")
                    {
                        foreach (var item in _inventory)
                        {
                            textArray = line.Split('|');
                            item.Value.UnitsSold = int.Parse(textArray[1]);
                            line = sr.ReadLine();
                        }

                    }
                }
            }
            catch(System.IO.FileNotFoundException)
            {
                UpdateSalesReport();
            }
        }
        #endregion
    }
}
