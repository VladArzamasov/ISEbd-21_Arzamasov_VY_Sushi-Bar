using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.HelperModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushi_BarBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly ISushiStorage _sushiStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(ISushiStorage sushiStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage)
        {
            _sushiStorage = sushiStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportSushiComponentViewModel> GetSushiComponent()
        {
            var components = _componentStorage.GetFullList();
            var sushis = _sushiStorage.GetFullList();
            var list = new List<ReportSushiComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportSushiComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Sushis = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var sushi in sushis)
                {
                    if (sushi.SushiComponents.ContainsKey(component.Id))
                    {
                        record.Sushis.Add(new Tuple<string, int>(sushi.SushiName,
                       sushi.SushiComponents[component.Id].Item2));
                        record.TotalCount +=
                       sushi.SushiComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom =
           model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                SushiName = x.SushiName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        // Сохранение компонент в файл-Word
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
        }
        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveSushiComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                SushiComponents = GetSushiComponent()
            });
        }
        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
