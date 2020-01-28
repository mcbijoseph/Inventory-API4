using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Domain_Layer;

namespace Inventory_Domain_Layer.Derived
{
    public class StockEntryDomain
    {
        public _007_invRefDocEntryListDomain DocEntry { get; set; }
        public _013_invItemsEntryListDomain[] ItemEntryList { get; set; }
        public _017_invDeliveryMethodEntryListDomain[] DeliveryEntry { get; set; }
    }
}
