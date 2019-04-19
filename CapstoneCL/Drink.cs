using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineBL
{
    public class Drink : Item
    {
        //string[] item;
        #region Constructor
        public Drink(string[] item) : base(item)
        {

        }
        #endregion
        #region Methods
        public override string Sound()
        {
            return "Glug Glug, Yum!";
        }
        #endregion
    }
}
