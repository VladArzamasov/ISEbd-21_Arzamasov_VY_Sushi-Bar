using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSushi_BarBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }
        public string ResponsiblePersonFCS { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> WarehouseComponents { get; set; }
    }
}
