using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    public class _021_invTransMasterListDomain
    {
        public int ID { get; set; }
        public string ReferenceNumber { get; set; }
        public int HardSeriesNumber { get; set; }
        public bool isCancelled { get; set; }
        public string cancelReason { get; set; }
        //public int ProjectID_ENGGDB { get; set; }
        //public int WarehouseInCharge_HRMSDB { get; set; }
        //public DateTime DatePrepared { get; set; }
        //public int ReceiverWarehouseInCharge_HRMSDB { get; set; }
        //public int ReceiverProjectID_ENGGDB { get; set; }
        public DateTime Date { get; set; }
        //public int DocEntryListID_007 { get; set; }
        public _022_invTransInfoOriginDomain TransInfoOrigin { get; set; }
        public _023_invTransInfoDestinationDomain TransInfoDestination { get; set; }
        public _024_invTransInfoDelMetAttrValueDomain TransInfoDelMetAttrValue { get; set; }
        public List<_025_invTransItemEntryListDomain> TransItemEntryList { get; set; }
        public List<_026_invTransItemReceivedListDomain> TransItemReceivedList { get; set; }
        public _031_invRefFormTransferListDomain FormTransfer { get; set; }

    }
}
