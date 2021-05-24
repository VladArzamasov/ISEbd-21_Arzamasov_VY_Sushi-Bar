using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushi_BarFileImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        private readonly FileDataListSingleton source;

        public WarehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<WarehouseViewModel> GetFullList()
        {
            return source.Warehouses
                .Select(CreateModel)
                .ToList();
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Warehouses
                .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                .Select(CreateModel)
                .ToList();
        }

        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);
            return warehouse != null ? CreateModel(warehouse) : null;
        }

        public void Insert(WarehouseBindingModel model)
        {
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
            var warehouse = new Warehouse
            {
                Id = maxId + 1,
                WarehouseComponents = new Dictionary<int, int>(),
                DateCreate = DateTime.Now
            };
            source.Warehouses.Add(CreateModel(model, warehouse));
        }

        public void Update(WarehouseBindingModel model)
        {
            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }
            CreateModel(model, warehouse);
        }

        public void Delete(WarehouseBindingModel model)
        {
            var warehouse = source.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

            if (warehouse == null)
            {
                throw new Exception("Склад не найден");
            }
            source.Warehouses.Remove(warehouse);
        }

        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePersonFCS = model.ResponsiblePersonFCS;
            // удаляем убранные
            foreach (var key in warehouse.WarehouseComponents.Keys.ToList())
            {
                if (!model.WarehouseComponents.ContainsKey(key))
                {
                    warehouse.WarehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.WarehouseComponents)
            {
                if (warehouse.WarehouseComponents.ContainsKey(component.Key))
                {
                    warehouse.WarehouseComponents[component.Key] =
                    model.WarehouseComponents[component.Key].Item2;
                }
                else
                {
                    warehouse.WarehouseComponents.Add(component.Key, model.WarehouseComponents[component.Key].Item2);
                }
            }
            return warehouse;
        }

        private WarehouseViewModel CreateModel(Warehouse warehouse)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> warehouseComponents = new Dictionary<int, (string, int)>();

            foreach (var warehouseComponent in warehouse.WarehouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (warehouseComponent.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                warehouseComponents.Add(warehouseComponent.Key, (componentName, warehouseComponent.Value));
            }
            return new WarehouseViewModel
            {
                Id = warehouse.Id,
                WarehouseName = warehouse.WarehouseName,
                ResponsiblePersonFCS = warehouse.ResponsiblePersonFCS,
                DateCreate = warehouse.DateCreate,
                WarehouseComponents = warehouseComponents
            };
        }

        public bool CheckAndTake(int count, Dictionary<int, (string, int)> components)
        {
            foreach (var component in components)
            {
                int requiredCount = component.Value.Item2 * count;
                int availableCount = source.Warehouses
                    .Where(rec => rec.WarehouseComponents.ContainsKey(component.Key))
                    .Sum(rec => rec.WarehouseComponents[component.Key]);
                if (availableCount < requiredCount)
                {
                    return false;
                }
            }
            foreach (var component in components)
            {
                int requiredCount = component.Value.Item2 * count;
                List<Warehouse> availableStoreHouses = source.Warehouses
                    .Where(rec => rec.WarehouseComponents.ContainsKey(component.Key))
                    .ToList();
                foreach (var warehouse in availableStoreHouses)
                {
                    int availableCount = warehouse.WarehouseComponents[component.Key];
                    if (availableCount <= requiredCount)
                    {
                        requiredCount = requiredCount - availableCount;
                        warehouse.WarehouseComponents.Remove(component.Key);
                    }
                    else
                    {
                        warehouse.WarehouseComponents[component.Key] -= requiredCount;
                        requiredCount = 0;
                    }
                    if (requiredCount == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }
    }
}
