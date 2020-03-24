using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _003_invRefItemFullNameDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Range(0, int.MaxValue)]
        public int Cat2ID_002 { get; set; }
        [Required]
        public string Name { get; set; }
        public bool hasAttribute { get; set; }
        //public List<_005_invRefPropertyName2Domain> Property2 { get; set; }
        public List<_033_invRefCategory3DefaultAttributeDomain> List { get; set; }

        public object ItemsMasterListInfo { get; set; }
        public object Category3Defaults { get; set; }
    }
}
