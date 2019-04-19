using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineBL
{
    public class Candy : Item
    {
        //string[] item;
        #region Constructor
        public Candy(string[] item) : base(item)
        {

        }
        #endregion
        #region Methods
        public override string Sound()
        {
            return "Munch Munch, Yum!";
        }
        #endregion
    }
}
