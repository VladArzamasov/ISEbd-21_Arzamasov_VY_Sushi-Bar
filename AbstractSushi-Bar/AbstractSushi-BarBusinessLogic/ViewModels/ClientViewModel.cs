using AbstractSushi_BarBusinessLogic.Attributes;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        [DataMember]
        public int? Id { get; set; }
        [Column(title: "ФИО", width: 150)]
        [DataMember]
        public string ClientFIO { get; set; }
        [Column(title: "Логин", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Email { get; set; }
        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DataMember]
        public string Password { get; set; }
    }
}
