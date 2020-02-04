using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    public class _025_invTransItemEntryListDomain
    {
        public int ID { get; set; }
        public int TransMasterID_021 { get; set; }
        public int ItemID_011 { get; set; }
        public int UnitsID_009 { get; set; }
        public decimal Quantity { get; set; }
        public int ItemCondID_018 { get; set; }
    }
}
