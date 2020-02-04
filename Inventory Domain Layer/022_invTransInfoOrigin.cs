using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    public class _022_invTransInfoOriginDomain
    {
        public int ID { get; set; }
        public int TransMasterID_021 { get; set; }
        public int ProjectID_EnggDB { get; set; }
        public int WHInchargeID_HrmsDB { get; set; }
        public int TransDelMethodID_024 { get; set; }
        public DateTime Date { get; set; }
    }
}
