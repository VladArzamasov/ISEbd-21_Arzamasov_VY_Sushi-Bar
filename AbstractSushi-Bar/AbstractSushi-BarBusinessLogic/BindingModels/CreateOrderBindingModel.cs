using System.Runtime.Serialization;
namespace AbstractSushi_BarBusinessLogic.BindingModels
{
    // Данные от клиента, для создания заказа
    [DataContract]
    public class CreateOrderBindingModel
    {
        [DataMember]
        public int ClientID { get; set; }
        [DataMember]
        public int SushiId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
