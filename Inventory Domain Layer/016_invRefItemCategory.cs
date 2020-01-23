using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _016_invRefItemCategoryDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Range(0, int.MaxValue)]
        public int Cat3ID_003 { get; set; }
        [Range(0, int.MaxValue)]
        public int ItemID_011 { get; set; }
    }
}
