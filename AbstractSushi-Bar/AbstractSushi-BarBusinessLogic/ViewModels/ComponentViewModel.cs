using AbstractSushi_BarBusinessLogic.Attributes;
using System.ComponentModel;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Компонент, требуемый для изготовления изделия
    public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }
    }
}
