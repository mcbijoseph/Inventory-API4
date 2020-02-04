using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _008_invRefDelMethodAttributeDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Range(0, int.MaxValue)]
        public int DelMethodID_010 { get; set; }

        [Required]
        public string MethodAttribute { get; set; }

        public List<_017_invNewInfoDelMetAttrValueDomain> DeliveryMethodEntryList
        {
            get; set;
        }
    }
}
