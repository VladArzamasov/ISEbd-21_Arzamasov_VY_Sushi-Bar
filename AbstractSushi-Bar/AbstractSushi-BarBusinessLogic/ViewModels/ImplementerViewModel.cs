﻿using AbstractSushi_BarBusinessLogic.Attributes;
using System.ComponentModel;

namespace AbstractSushi_BarBusinessLogic.ViewModels
{
    // Исполнитель, выполняющий заказы
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ImplementerFIO { get; set; }
        [Column(title: "Время на заказ", width: 100)]
        public int WorkingTime { get; set; }
        [Column(title: "Время на перерыв", width: 100)]
        public int PauseTime { get; set; }
    }
}
