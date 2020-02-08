﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    public class _027_invWithdrawMasterListDomain
    {
        public int ID { get; set; }
        public string CtrlNumber { get; set; }
        public int WidraweeNameID_Hrms { get; set; }
        public int ProjectNameID_EnggDB { get; set; }
        public int RequestedByID_HrmsDB { get; set; }
        public int ApprovedByID_HrmsDB { get; set; }
        public int ReceivedByID_HrmsDB { get; set; }
        public DateTime Date { get; set; }

        public object ProjectInfo
        {
            get { return ApiReferenceHolder.GetProjectByID(ProjectNameID_EnggDB); }
        }
    }
}
