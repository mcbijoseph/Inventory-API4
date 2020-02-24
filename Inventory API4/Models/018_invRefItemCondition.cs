using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _018_invRefItemConditionDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        public string StatusName { get; set; }
    }
}
