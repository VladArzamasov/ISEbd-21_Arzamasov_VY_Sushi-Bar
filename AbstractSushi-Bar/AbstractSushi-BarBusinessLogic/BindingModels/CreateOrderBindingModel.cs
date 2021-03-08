namespace AbstractSushi_BarBusinessLogic.BindingModels
{
    // Данные от клиента, для создания заказа
    public class CreateOrderBindingModel
    {
        public int SushiId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
