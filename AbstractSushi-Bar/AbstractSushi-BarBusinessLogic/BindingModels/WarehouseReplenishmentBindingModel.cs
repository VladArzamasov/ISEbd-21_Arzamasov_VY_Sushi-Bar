using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSushi_BarBusinessLogic.BindingModels
{
    public class WarehouseReplenishmentBindingModel
    {
        public int ComponentId { get; set; }
        public int WarehouseId { get; set; }
        public int Count { get; set; }
    }
}
