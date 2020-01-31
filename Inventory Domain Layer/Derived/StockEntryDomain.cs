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
        public List< _013_invItemsEntryListDomain> ItemEntryList { get; set; }
        public List< _017_invDeliveryMethodEntryListDomain> DeliveryEntry { get; set; }
    }
}
