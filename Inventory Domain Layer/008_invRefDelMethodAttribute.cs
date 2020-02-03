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
        [Required]
        [Range(0, int.MaxValue)]
        public int DelMethodID_010 { get; set; }
        public string MethodAttribute { get; set; }

        public List<_017_invDeliveryMethodEntryListDomain> DeliveryMethodEntryList
        {
            get; set;
        }
    }
}
