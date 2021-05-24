using AbstractSushi_BarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractSushi_BarBusinessLogic.HelperModels
{
    public class PdfInfoForOrder
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrderByDateViewModel> Orders { get; set; }
    }
}
