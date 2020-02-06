using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _011_invRefItemsMasterListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public String Code { get; set; }
        public String Tag { get; set; }
        public bool hasAttribute { get; set; }

        public List<_014_invRefItemImageDomain> ItemImage { get; set; }
        public List<_012_invItemAttributeDomain> ItemAttribute { get; set; }
        public _003_invRefCategory3Domain Category3 { get; set; }
        public ItemFullNameDomain ItemFullNameInfo { get; set; }
        
    }
}
