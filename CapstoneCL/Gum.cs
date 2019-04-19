using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineBL
{
    public class Gum : Item
    {
        //string[] item;
        #region Constructor
        public Gum(string[] item) : base(item)
        {

        }
        #endregion
        #region Methods
        public override string Sound()
        {
            return "Chew Chew, Yum!";
        }
        #endregion
    }
}
