using System;
using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    public class ReportSushiComponentViewModel
    {
        public string SushiName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
