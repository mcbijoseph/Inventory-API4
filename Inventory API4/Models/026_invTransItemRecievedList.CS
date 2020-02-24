using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_API4.Models
{
    public class _026_invTransItemReceivedListDomain
    {
        public int ID { get; set; }
        public int TransMasterID_021 { get; set; }
        public int ItemID_011 { get; set; }
        public int UnitsID_009 { get; set; }
        public decimal Quantity { get; set; }
        public int ItemCondID_018 { get; set; }
        public int ReceiverID_HrmsDB { get; set; }
        public int DelMethodID_024 { get; set; }

        public object ReceiverByInfo => ApiReferenceHolder.getHrmsbyID(ReceiverID_HrmsDB);
    }
}
