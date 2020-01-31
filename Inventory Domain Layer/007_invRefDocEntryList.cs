using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _007_invRefDocEntryListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int SupID_VendorDB { get; set; }
        [Range(0, int.MaxValue)]
        public int ProjectID_EnggDB { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime EntryDate { get; set; }
        [Range(0, int.MaxValue)]
        public int ReceiverID_HRDB { get; set; }

        public _013_invItemsEntryListDomain[] ItemEntryList { get; set; }
        public _017_invDeliveryMethodEntryListDomain[] DeliveryEntry { get; set; }
    }
}
