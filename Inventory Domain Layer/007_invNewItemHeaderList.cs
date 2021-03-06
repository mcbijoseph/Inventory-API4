﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _007_invNewItemHeaderListDomain
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

        public List<_013_invNewItemEntryListDomain> ItemEntryList { get; set; }
        public _010_invRefDeliveryMethodDomain DeliveryMethod { get; set; }

        public object ReceiverInfo => ApiReferenceHolder.getHrmsbyID(ReceiverID_HRDB);
        public object ProjectInfo => ApiReferenceHolder.GetProjectByID(ProjectID_EnggDB);
        public object SupInfo => ApiReferenceHolder.getSupplierbyID(SupID_VendorDB);

    }
}
