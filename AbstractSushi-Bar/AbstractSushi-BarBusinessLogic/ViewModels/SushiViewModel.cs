using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Изделие, изготавливаемое в баре
    public class SushiViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string SushiName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SushiComponents { get; set; }
    }
}
