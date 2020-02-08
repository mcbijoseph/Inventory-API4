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
        public int Requestedby_HRMSDB { get; set; }
        public int Approvedby_HRMSDB { get; set; }
        public int Receivedby_HRMSDB { get; set; }
        public DateTime ReceivedDate { get; set; }

        public object ProjectInfo => ApiReferenceHolder.GetProjectByID(ProjectID_ENGGDB);
        public object RequestedByInfo => ApiReferenceHolder.getHrmsbyID(Requestedby_HRMSDB);
        public object ApprovedByInfo => ApiReferenceHolder.getHrmsbyID(Approvedby_HRMSDB);
        public object ReceivedByInfo => ApiReferenceHolder.getHrmsbyID(Receivedby_HRMSDB);
    }
}
