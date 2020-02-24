using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_API4.Models
{
    public class vwItemProjectQuantity
    {
        public int ItemID_011 { get; set; }
        public int ProjectID { get; set; }
        public string ItemFullName { get; set; }
        public decimal Quantity { get; set; }

        public object ProjectInfo => ApiReferenceHolder.GetProjectByID(ProjectID);
    }
}
