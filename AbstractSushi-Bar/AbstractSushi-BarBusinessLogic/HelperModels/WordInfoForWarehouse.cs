using AbstractSushi_BarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSushi_BarBusinessLogic.HelperModels
{
    public class WordInfoForWarehouse
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
