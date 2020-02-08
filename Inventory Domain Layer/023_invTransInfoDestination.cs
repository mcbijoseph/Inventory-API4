using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Inventory_Domain_Layer
{
    public class _023_invTransInfoDestinationDomain
    {
        public int ID { get; set; }
        public int TransMasterID_021 { get; set; }
        public int ProjectID_EnggDB { get; set; }
        public int WHInchargeID_HrmsDB { get; set; }

        public object ProjectInfo => ApiReferenceHolder.GetProjectByID(ProjectID_EnggDB);
        public object WHInchargeInfo => ApiReferenceHolder.getHrmsbyID(WHInchargeID_HrmsDB);
    }
}
