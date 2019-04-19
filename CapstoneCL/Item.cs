using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineBL
{
    public abstract class Item
    {
        #region Properties
        //private string[] Items { get; }
        public int UnitsSold { get; set; }
        public string Position { get; }
        public string ItemName { get;}
        public decimal Price { get; }
        public int Quantity { get; set; }
        private string TypeOfItem { get; }

        
        #endregion
        #region Constructor
        public Item(string[] items)
        {
            Position = items[0];
            ItemName = items[1];
            Price = decimal.Parse(items[2]);
            Quantity = 5;
        }

        protected Item()
        {
        }
        #endregion
        #region Methods
        public abstract string Sound();
        #endregion
    }
}
