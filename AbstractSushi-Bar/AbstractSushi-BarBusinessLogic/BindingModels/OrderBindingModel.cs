using AbstractSushi_BarBusinessLogic.Enums;
using System;

namespace AbstractSushi_BarBusinessLogic.BindingModels
{
    // Заказ
    public class OrderBindingModel
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
    }
}
