using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Brickstore
{
    internal class LegoClass
    {
        private string itemID;
        private string itemName;
        private string categoryName;
        private string colorName;
        private int qty;

        public LegoClass(string itemID, string itemName, string categoryName, string colorName, int qty)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.categoryName = categoryName;
            this.colorName = colorName;
            this.qty = qty;
        }

        public string ItemID { get { return itemID; } }
        public string ItemName { get { return itemName; } }
        public string CategoryName { get {return categoryName; } }
        public string ColorName { get {return colorName;} }
        public int Qty { get {return qty;} }
    }
}
