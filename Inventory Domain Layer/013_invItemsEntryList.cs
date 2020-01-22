using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    class _013_invItemsEntryList
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public decimal Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitID { get; set; }
        public int TDSID { get; set; }
        public int DelID { get; set; }
        public int EntID { get; set; }
        public int Sup_ID { get; set; }
        public int Emp_Receive_ID { get; set; }
    }
}
