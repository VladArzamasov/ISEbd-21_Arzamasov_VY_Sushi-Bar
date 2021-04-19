using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Изделие, изготавливаемое в баре
    [DataContract]
    public class SushiViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название изделия")]
        public string SushiName { get; set; }
        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> SushiComponents { get; set; }
    }
}
