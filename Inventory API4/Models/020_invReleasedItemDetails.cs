using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_API4.Models
{
    public class _020_invReleasedItemDetailsDomain
    {
        public int ID { get; set; }
        public int HeaderID_019 { get; set; }
        public int ItemID_011 { get; set; }
        public decimal Qty { get; set; }
        public string Remarks { get; set; }
    }
}
