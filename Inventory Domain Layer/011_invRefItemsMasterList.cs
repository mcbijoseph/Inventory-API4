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
        public String Name { get; set; }
        public String Code { get; set; }
        public String Tag { get; set; }
        public Boolean has_Attribute { get; set; }
    }
}
