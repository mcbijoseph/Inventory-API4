﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    public class _021_invTransferedItemsHeaderDomain
    {
        public int ID { get; set; }
        public string Ctrlnumber { get; set; }
        public int ProjectID_ENGGDB { get; set; }
        public int WarehouseInCharge_HRMSDB { get; set; }
        public DateTime DatePrepared { get; set; }
        public int ReceiverWarehouseInCharge_HRMSDB { get; set; }
        public int ReceiverProjectID_ENGGDB { get; set; }
        public DateTime ReceivedDate { get; set; }
        public int DocEntryListID_007 { get; set; }

    }
}