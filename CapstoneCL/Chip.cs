using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineBL
{
    public class Chip : Item
    {       
        //string[] item;
        #region Constructor
        public Chip(string[] item) : base(item)
        {
            
        }
        #endregion
        #region Methods
        public override string Sound()
        {
            return "Crunch Crunch, Yum!";
        }
        #endregion
    }
}
