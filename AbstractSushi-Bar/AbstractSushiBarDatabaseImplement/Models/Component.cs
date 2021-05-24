﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractSushiBarDatabaseImplement.Models
{
    public class Component
    {
        public int Id { get; set; }
        [Required]
        public string ComponentName { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<SushiComponent> SushiComponents { get; set; }
        [ForeignKey("ComponentId")]
        public virtual List<WarehouseComponent> WarehouseComponents { get; set; }
    }
}
