﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _004_invRefPropertyName1Domain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set;}
        [Required]
        public string Name { get; set; }
      
        public List<_005_invRefPropertyName2Domain> Property2
        {
            get; set;
        }

    }
}
