using Microsoft.EntityFrameworkCore;
using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushiBarDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushiBarDatabaseImplement.Implements
{
    public class WarehouseStorage : IWarehouseStorage
    {
        public WarehouseViewModel GetElement(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AbstractSushiBarDatabase())
            {
                var warehouse = context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WarehouseName == model.WarehouseName || rec.Id == model.Id);

                return warehouse != null ?
                    new WarehouseViewModel
                    {
                        Id = warehouse.Id,
                        WarehouseName = warehouse.WarehouseName,
                        ResponsiblePersonFCS = warehouse.ResponsiblePersonFCS,
                        DateCreate = warehouse.DateCreate,
                        WarehouseComponents = warehouse.WarehouseComponents
                            .ToDictionary(recWarehouseComponent => recWarehouseComponent.ComponentId,
                            recWarehouseComponent => (recWarehouseComponent.Component?.ComponentName,
                            recWarehouseComponent.Count))
                    } :
                    null;
            }
        }

        public List<WarehouseViewModel> GetFilteredList(WarehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.WarehouseName.Contains(model.WarehouseName))
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        ResponsiblePersonFCS = rec.ResponsiblePersonFCS,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWarehouseComponent => recWarehouseComponent.ComponentId,
                            recWarehouseComponent => (recWarehouseComponent.Component?.ComponentName,
                            recWarehouseComponent.Count))
                    })
                    .ToList();
            }
        }

        public List<WarehouseViewModel> GetFullList()
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Warehouses.Count() == 0 ? new List<WarehouseViewModel>() :
                    context.Warehouses
                    .Include(rec => rec.WarehouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new WarehouseViewModel
                    {
                        Id = rec.Id,
                        WarehouseName = rec.WarehouseName,
                        ResponsiblePersonFCS = rec.ResponsiblePersonFCS,
                        DateCreate = rec.DateCreate,
                        WarehouseComponents = rec.WarehouseComponents
                            .ToDictionary(recWarehouseComponents => recWarehouseComponents.ComponentId,
                            recWarehouseComponents => (recWarehouseComponents.Component?.ComponentName,
                            recWarehouseComponents.Count))
                    })
                    .ToList();
            }
        }
        public void Insert(WarehouseBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Warehouse(), context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(WarehouseBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                        if (warehouse == null)
                        {
                            throw new Exception("Склад не найден");
                        }

                        CreateModel(model, warehouse, context);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(WarehouseBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                var warehouse = context.Warehouses.FirstOrDefault(rec => rec.Id == model.Id);

                if (warehouse == null)
                {
                    throw new Exception("Склад не найден");
                }

                context.Warehouses.Remove(warehouse);
                context.SaveChanges();
            }
        }
        public bool CheckAndTake(int count, Dictionary<int, (string, int)> components)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var component in components)
                        {
                            int requiredCount = component.Value.Item2 * count;
                            IEnumerable<WarehouseComponent> warehouseComponents = context.WarehouseComponents
                                .Where(rec => rec.ComponentId == component.Key);

                            foreach (WarehouseComponent warehouseComponent in warehouseComponents)
                            {
                                if (warehouseComponent.Count <= requiredCount)
                                {
                                    requiredCount -= warehouseComponent.Count;
                                    context.WarehouseComponents.Remove(warehouseComponent);
                                }
                                else
                                {
                                    warehouseComponent.Count -= requiredCount;
                                    requiredCount = 0;
                                    break;
                                }
                            }

                            if (requiredCount != 0)
                            {
                                throw new Exception("Не хвататет компонентов на складе");
                            }
                        }

                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        private Warehouse CreateModel(WarehouseBindingModel model, Warehouse warehouse, AbstractSushiBarDatabase context)
        {
            warehouse.WarehouseName = model.WarehouseName;
            warehouse.ResponsiblePersonFCS = model.ResponsiblePersonFCS;
            if (warehouse.Id == 0)
            {
                warehouse.DateCreate = DateTime.Now;
                context.Warehouses.Add(warehouse);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var warehouseComponents = context.WarehouseComponents
                    .Where(rec => rec.WarehouseId == model.Id.Value)
                    .ToList();

                context.WarehouseComponents.RemoveRange(warehouseComponents
                    .Where(rec => !model.WarehouseComponents.ContainsKey(rec.ComponentId))
                    .ToList());
                context.SaveChanges();

                foreach (var updateComponent in warehouseComponents)
                {
                    updateComponent.Count = model.WarehouseComponents[updateComponent.ComponentId].Item2;
                    model.WarehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }

            foreach (var warehouseComponent in model.WarehouseComponents)
            {
                context.WarehouseComponents.Add(new WarehouseComponent
                {
                    WarehouseId = warehouse.Id,
                    ComponentId = warehouseComponent.Key,
                    Count = warehouseComponent.Value.Item2
                });
                context.SaveChanges();
            }

            return warehouse;
        }
    }
}
