using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    public class ReportWarehouseComponentsViewModel
    {
        public string WarehouseName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
    }
}
