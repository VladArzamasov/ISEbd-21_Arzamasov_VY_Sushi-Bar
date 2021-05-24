using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.HelperModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushi_BarBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IWarehouseStorage _warehouseStorage;
        private readonly ISushiStorage _sushiStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(ISushiStorage sushiStorage, IWarehouseStorage
       warehouseStorage, IOrderStorage orderStorage)
        {
            _sushiStorage = sushiStorage;
            _warehouseStorage = warehouseStorage;
            _orderStorage = orderStorage;
        }
        // Получение списка компонент с указанием, в каких изделиях используются
        public List<ReportSushiComponentViewModel> GetSushiComponent()
        {
            var sushis = _sushiStorage.GetFullList();
            var list = new List<ReportSushiComponentViewModel>();
            foreach (var sushi in sushis)
            {
                var record = new ReportSushiComponentViewModel
                {
                    SushiName = sushi.SushiName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in sushi.SushiComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
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
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                SushiName = x.SushiName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            })
           .ToList();
        }
        public List<ReportWarehouseComponentsViewModel> GetWarehouseComponent()
        {
            var warehouses = _warehouseStorage.GetFullList();

            var list = new List<ReportWarehouseComponentsViewModel>();

            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseComponentsViewModel
                {
                    WarehouseName = warehouse.WarehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in warehouse.WarehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportOrderByDateViewModel> GetOrdersInfo()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate
                .ToShortDateString())
                .Select(rec => new ReportOrderByDateViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }
        // Сохранение компонент в файл-Word
        public void SaveSushisToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список суши",
                Sushis = _sushiStorage.GetFullList()
            });
        }
        // Сохранение компонент с указаеним продуктов в файл-Excel
        public void SaveSushiComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список суши",
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
        public void SaveWarehouseComponentsToExcel(ReportBindingModel model)
        {
            SaveToExcel.CreateDocForWarehouse(new ExcelInfoForWarehouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                WarehouseComponents = GetWarehouseComponent()
            });
        }

        public void SaveOrdersInfoToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocForWarehouse(new PdfInfoForOrder
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersInfo()
            });
        }

        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocForWarehouse(new WordInfoForWarehouse
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = _warehouseStorage.GetFullList()
            });
        }
    }
}
