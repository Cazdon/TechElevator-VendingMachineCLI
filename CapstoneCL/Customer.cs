using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineBL
{
    public class Customer
    {
        #region Member Variables
        private const int _quarter = 25;
        private const int _nickel = 5;
        private const int _dime = 10;       
        #endregion

        #region Properties
        public decimal Balance { get; private set; }
        #endregion

        #region Constructor
        public Customer()
        {
            Balance = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds money to Customer Balance property
        /// </summary>
        public void FeedMoney(decimal amount)
        {
            if (amount >= 0 && Balance != decimal.MaxValue)
            {
                Balance += amount;
            }
            else
            {
                throw new Exception("Cannot feed a negative value");
            }
        }

        /// <summary>
        /// Subtracts money from Customer Balance 
        /// </summary>
        public void SpendMoney(decimal price)
        {
            if(Balance >= price)
            {
                Balance -= price;
            }
            else
            {
                throw new Exception("Insuffient Funds, cannot spend more money than you have");
            }
        }

        /// <summary>
        /// Returns the customers balance in the smallest amount of coins, and sets it to 0.
        /// </summary>
        public string ReturnChange()
        {
            int quartersReturned = 0;
            int dimesReturned = 0;
            int nickelsReturned = 0;
            Balance = Balance * 100; //Converts to pennies

            if (Balance >= _nickel)
            {
                quartersReturned = (int)Balance / _quarter;
                Balance = (int)Balance % _quarter;
                dimesReturned = (int)Balance / _dime;
                Balance = (int)Balance % _dime;
                nickelsReturned = (int)Balance / _nickel;
                Balance = Balance % _nickel;
            }
            return $"Quarters: {quartersReturned} - Nickels: {nickelsReturned} - Dimes: {dimesReturned}";
        }

        /// <summary>
        /// Sets the balance of the Customer for Unit Testing purposes
        /// </summary>
        public void ResetBalance(decimal balance)
        {
            Balance = balance;
        }
        #endregion
    }
}
