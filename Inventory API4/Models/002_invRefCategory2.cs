using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _002_invRefCategory2Domain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Range(0, int.MaxValue)]
        public int Cat1ID_001 { get; set; }
        [Required]
        public string Name { get; set; }

        public List<_003_invRefItemFullNameDomain> Category3
        {
            get; set;
        }
    }
}
