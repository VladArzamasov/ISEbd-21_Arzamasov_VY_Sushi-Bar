using AbstractSushi_BarBusinessLogic.Attributes;
using AbstractSushi_BarBusinessLogic.Enums;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Заказ
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 50)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int SushiId { get; set; }
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Исполнитель", width: 150)]
        [DataMember]
        public string ImplementerFIO { get; set; }
        [Column(title: "Изделие", width: 100)]
        [DataMember]
        public string SushiName { get; set; }
        [Column(title: "Количество", width: 100)]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 50)]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Column(title: "Дата создания", width: 100)]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 100)]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}
