using System;
using VendingMachineBL;
using System.IO;
using System.Collections.Generic;

namespace VendingMachineCLI
{
    public class VendingMachineCLI
    {
        public VendingMachine _machine = null;
        Customer customer = new Customer();
        #region Member Variables
        #endregion

        #region Properties
        private string MachineName { get; }
        #endregion

        #region Constructors
        public VendingMachineCLI (VendingMachine machine)
        {
            _machine = machine;

            DisplaySplashScreen();
        }
        #endregion

        #region Methods
        /// <summary>
        /// The main method for displaying infomation and inputs to the user. 
        /// </summary>
        public void MainMenu()
        {
            bool mainIsRunning = true;

            while (mainIsRunning)
            {
                Console.Clear();
                Console.WriteLine("(1) Display Vending Machine Products");
                Console.WriteLine("(2) Purchase Menu");
                Console.WriteLine("(3) Sales Report");
                Console.WriteLine("(4) Exit");
                Console.WriteLine();

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 4);
                if (selection == 1)
                {
                    mainIsRunning = false;
                    DisplayItemsMenu();
                }
                else if (selection == 2)
                {
                    mainIsRunning = false;
                    PurchaseMenu();
                }
                else if (selection == 3)
                {
                    mainIsRunning = false;
                    SalesReportMenu();                   
                }
                else if (selection == 4)
                {
                    mainIsRunning = false;
                }
            }
        }
        public void PurchaseMenu()
        {
            bool inPurchaseMenu = true;

            while (inPurchaseMenu)
            {
                Console.Clear();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Feed Money");
                Console.WriteLine("(3) Select Product");
                Console.WriteLine("(4) Finish Transaction");
                Console.WriteLine("(5) Go back");
                Console.WriteLine();

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 5);
                if (selection == 1)
                {
                    inPurchaseMenu = false;
                    DisplayItemsMenu();
                }
                else if (selection == 2)
                {
                    inPurchaseMenu = false;
                    FeedMoneyMenu();
                }
                else if (selection == 3)
                {
                    inPurchaseMenu = false;
                    SelectItemMenu();
                }
                else if (selection == 4)
                {
                    inPurchaseMenu = false;
                    Console.WriteLine();
                    _machine.AuditLogReport("GIVE CHANGE", customer.Balance, 0.00M);
                    Console.WriteLine($"Your change is :{customer.ReturnChange()}");                    
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    MainMenu();
                }
                else if (selection == 5)
                {
                    inPurchaseMenu = false;
                    MainMenu();
                }
            }
            inPurchaseMenu = false;
            
        }
        
        public void SalesReportMenu()
        {
            bool inSalesReportMenu = true;

            while (inSalesReportMenu)
            {
                Console.Clear();
                Console.WriteLine("(1) Go Back");
                Console.WriteLine();
                _machine.UpdateSalesReport();
                Console.Write(_machine.ReadSalesReport());

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 1);
                if (selection == 1)
                {
                    inSalesReportMenu = false;
                    MainMenu();
                }              
            }
            inSalesReportMenu = false;            
        }

        public void DisplaySplashScreen()
        {
            string splashScreenFilePath = $@"{Environment.CurrentDirectory}\..\..\..\..\etc\SplashScreen.txt";

            using (StreamReader sr = new StreamReader(splashScreenFilePath))
            {
                while (!sr.EndOfStream)
                {
                    Console.WriteLine(sr.ReadLine());
                }
            }
            System.Threading.Thread.Sleep(2000);
        }

        public void FeedMoneyMenu()
        {
            bool inFeedMoneyMenu = true;

            while (inFeedMoneyMenu)
            {
                Console.Clear();
                Console.WriteLine("(1) Feed $1");
                Console.WriteLine("(2) Feed $2");
                Console.WriteLine("(3) Feed $5");
                Console.WriteLine("(4) Feed $10");
                Console.WriteLine("(5) Go Back");
                Console.WriteLine();
                Console.WriteLine($"You have ${customer.Balance} to spend");

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 5);
                if (selection == 1)
                {
                    customer.FeedMoney(1);
                    _machine.AuditLogReport("FEED MONEY", 1, customer.Balance);

                }
                else if (selection == 2)
                {
                    customer.FeedMoney(2);
                    _machine.AuditLogReport("FEED MONEY", 2, customer.Balance);
                }
                else if (selection == 3)
                {
                    customer.FeedMoney(5);
                    _machine.AuditLogReport("FEED MONEY", 5, customer.Balance);
                }
                else if (selection == 4)
                {
                    customer.FeedMoney(10);
                    _machine.AuditLogReport("FEED MONEY", 10, customer.Balance);
                }
                else if (selection == 5)
                {
                    inFeedMoneyMenu = false;
                    PurchaseMenu();
                }
            }
            inFeedMoneyMenu = false;
        }
        public void DisplayItemsMenu()
        {
            bool inDispayItemsMenu = true;

            while (inDispayItemsMenu)
            {
                Console.Clear();
                Console.WriteLine("(1) Go Back");
                Console.WriteLine();
                foreach (var item in _machine._inventory)
                {
                    if (item.Value.Quantity == 0)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value.ItemName} Price: ${item.Value.Price} Quantity: SOLD OUT");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key}: {item.Value.ItemName} Price: ${item.Value.Price} Quantity: {item.Value.Quantity}");
                    }
                }
                Console.WriteLine();

                int selection = CLIHelper.GetSingleInteger("Select an option...", 1, 1);
                if (selection == 1)
                {
                    inDispayItemsMenu = false;
                    MainMenu();
                }
            }
            inDispayItemsMenu = false;
        }
        public void SelectItemMenu()
        {
            bool inSelectItemMenu = true;

            while (inSelectItemMenu)
            {
                Console.Clear();
                Console.WriteLine($"You have ${customer.Balance} to spend");
                Console.WriteLine();
                foreach (var item in _machine._inventory)
                {
                    if (item.Value.Quantity == 0)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value.ItemName} Price: ${item.Value.Price} Quantity: SOLD OUT");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key}: {item.Value.ItemName} Price: ${item.Value.Price} Quantity: {item.Value.Quantity}");
                    }
                }
                Console.WriteLine();
                string selection = CLIHelper.GetString("Select a type of item.").ToUpper();
                try
                {
                    var itemSelected = _machine._inventory[selection];

                    if (itemSelected.Quantity > 0)
                    {
                        if (customer.Balance >= itemSelected.Price)
                        {
                            _machine.AuditLogReport($"{itemSelected.ItemName} {itemSelected.Position}", customer.Balance, (customer.Balance - itemSelected.Price));
                            customer.SpendMoney(itemSelected.Price);
                            _machine.DispenseItem(selection);                           
                            _machine.UpdateSalesReport();

                            Console.WriteLine($"{itemSelected.ItemName} Cost: ${itemSelected.Price} Balance remaining: ${customer.Balance}");
                            Console.WriteLine(itemSelected.Sound());

                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                            inSelectItemMenu = false;
                        }
                        else
                        {
                            Console.WriteLine("You do not have the funds to purchase this item. Press any key to continue");
                            Console.ReadKey();
                            inSelectItemMenu = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The item you have selected is out of stock. Press any key to continue");
                        Console.ReadKey();
                        inSelectItemMenu = false;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("You've entered an invalid selection. Press any key to continue");
                    Console.ReadKey();
                    inSelectItemMenu = false;
                }               
            }
            inSelectItemMenu = false;
            PurchaseMenu();
        }
        #endregion
    }
}
