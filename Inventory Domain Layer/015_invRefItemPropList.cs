using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    class _015_invRefItemPropList
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Range(0, int.MaxValue)]
        public int Cat3ID_003 { get; set; }
        [Range(0, int.MaxValue)]
        public int Prop2ID_005 { get; set; }
    }
}
