using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    public class _022_invTransferedItemsDetailsDomain
    {
        public int ID { get; set; }
        public int HeaderID_021 { get; set; }
        public int ItemID_011 { get; set; }
        public int UnitID_009 { get; set; }
        public decimal Quantity { get; set; }
        public int ItemConditionId_018 { get; set; }
    }
}
