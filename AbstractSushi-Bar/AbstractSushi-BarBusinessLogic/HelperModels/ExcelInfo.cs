using AbstractSushi_BarBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportSushiComponentViewModel> SushiComponents { get; set; }
    }
}
