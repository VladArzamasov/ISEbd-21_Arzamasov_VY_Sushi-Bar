using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.BindingModels
{
    // Изделие, изготавливаемое в суши-баре
    public class SushiBindingModel
    {
        public int? Id { get; set; }
        public string SushiName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> SushiComponents { get; set; }
    }
}
