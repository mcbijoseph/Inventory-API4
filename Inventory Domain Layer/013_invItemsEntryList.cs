using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _013_invItemsEntryListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemID_011 { get; set; }

        public decimal Qty { get; set; }

        public decimal UnitPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitID_009 { get; set; }

        [Range(0, int.MaxValue)]
        public int TDSID_010 { get; set; }

        [Range(0, int.MaxValue)]
        public int DelID_007 { get; set; }

        [Range(0, int.MaxValue)]
        public int EntID_008 { get; set; }

        [Range(0, int.MaxValue)]
        public int Sup_ID { get; set; }

        [Range(0, int.MaxValue)]
        public int Emp_Receive_ID { get; set; }
    }
}
