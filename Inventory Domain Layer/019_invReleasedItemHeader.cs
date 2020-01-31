using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    
    public class _019_invReleasedItemHeaderDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        public string  Ctrlnumber { get; set; }
        public int ProjectID_ENGGDB { get; set; }
        public DateTime Date { get; set; }
        public int RequestbyHRMSDB { get; set; }
        public int ApprovedbyHRMSDB { get; set; }
        public int ReceivedbyHRMSDB { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
