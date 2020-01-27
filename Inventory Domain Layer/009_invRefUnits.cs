using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _009_invRefUnitsDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public string ShortName { get; set; }
        public string FullName { get; set; }
    }
}
