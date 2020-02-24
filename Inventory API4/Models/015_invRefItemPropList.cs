using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _015_invRefItemPropListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Range(0, int.MaxValue)]
        public int MasterListID_011 { get; set; }
        public int Cat3ID_003 { get; set; }
        [Range(0, int.MaxValue)]
        public int Prop2ID_005 { get; set; }
        public string PropValue { get; set; }
        //public _003_invRefCategory3Domain ItemPropList { get; set; }
    }
}
