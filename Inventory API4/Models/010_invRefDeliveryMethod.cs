using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _010_invRefDeliveryMethodDomain
    {
        [Range(0,  int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public List<_008_invRefDelMethodAttributeDomain> DelMethodAttribute
        {
            get; set;
        }
    }
}
