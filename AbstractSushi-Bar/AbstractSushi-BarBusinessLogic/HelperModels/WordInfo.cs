using AbstractSushi_BarBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<SushiViewModel> Sushis { get; set; }
    }
}
