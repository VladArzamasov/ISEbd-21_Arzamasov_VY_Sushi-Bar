using AbstractSushi_BarBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Изделие, изготавливаемое в баре
    [DataContract]
    public class SushiViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string SushiName { get; set; }
        [DataMember]
        [Column(title: "Цена", width: 100)]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> SushiComponents { get; set; }
    }
}
