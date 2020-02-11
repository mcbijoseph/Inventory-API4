using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _001_invRefCategory1Domain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        //public bool isDeleted { get; set; }

        public List<_002_invRefCategory2Domain> Category2 {get; set;}
    }
}
