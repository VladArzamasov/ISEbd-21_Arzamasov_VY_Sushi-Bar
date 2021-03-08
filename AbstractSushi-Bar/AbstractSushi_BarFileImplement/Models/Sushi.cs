using System.Collections.Generic;

namespace AbstractSushi_BarFileImplement.Models
{
    public class Sushi
    {
        public int Id { get; set; }
        public string SushiName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> SushiComponents { get; set; }
    }
}
