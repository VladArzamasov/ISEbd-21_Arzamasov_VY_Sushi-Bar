using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Изделие, изготавливаемое в баре
    public class ProductViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
