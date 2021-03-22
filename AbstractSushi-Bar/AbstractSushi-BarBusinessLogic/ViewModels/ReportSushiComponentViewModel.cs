using System;
using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    public class ReportSushiComponentViewModel
    {
        public string ComponentName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Sushis { get; set; }
    }
}
