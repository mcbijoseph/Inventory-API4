using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _011_invRefItemsMasterListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        public int Cat3ID_003 { get; set; }
        //[Required]
        public String Code { get; set; }
        public String Tag { get; set; }
        public bool hasAccountability { get; set; }

        public _009_invRefUnitsDomain Units { get; set; }
        public List<vwItemProjectQuantity> ProjectQuantity { get; set; }

        public List<_014_invRefItemImageDomain> ItemImage { get; set; }
        public List<_012_invItemAttributeDomain> ItemAttribute { get; set; }
        public _003_invRefItemFullNameDomain Category3 { get; set; }
        public fnItemFullNameDomain ItemFullNameInfo { get; set; }

        
    }
}
