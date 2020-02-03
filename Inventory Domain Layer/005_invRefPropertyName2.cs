using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _005_invRefPropertyName2Domain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Range(0, int.MaxValue)]
        public int Prop1ID_004 { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        public List<_015_invRefItemPropListDomain> ItemPropList { get; set;}
    }
}
