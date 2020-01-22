using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _013_invItemsEntryList
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemID { get; set; }

        public decimal Qty { get; set; }

        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitID { get; set; }

        [Range(0, int.MaxValue)]
        public int TDSID { get; set; }

        [Range(0, int.MaxValue)]
        public int DelID { get; set; }

        [Range(0, int.MaxValue)]
        public int EntID { get; set; }

        [Range(0, int.MaxValue)]
        public int Sup_ID { get; set; }

        [Range(0, int.MaxValue)]
        public int Emp_Receive_ID { get; set; }
    }
}
