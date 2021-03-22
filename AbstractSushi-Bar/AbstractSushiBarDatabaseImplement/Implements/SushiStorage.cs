using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushiBarDatabaseImplement.Implements
{
    public class SushiStorage : ISushiStorage
    {
        public List<SushiViewModel> GetFullList()
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Sushi
                .Include(rec => rec.SushiComponents)
               .ThenInclude(rec => rec.Component)
               .ToList()
               .Select(rec => new SushiViewModel
               {
                   Id = rec.Id,
                   SushiName = rec.SushiName,
                   Price = rec.Price,
                   SushiComponents = rec.SushiComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<SushiViewModel> GetFilteredList(SushiBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Sushi
                .Include(rec => rec.SushiComponents)
               .ThenInclude(rec => rec.Component)
               .Where(rec => rec.SushiName.Contains(model.SushiName))
               .ToList()
               .Select(rec => new SushiViewModel
               {
                   Id = rec.Id,
                   SushiName = rec.SushiName,
                   Price = rec.Price,
                   SushiComponents = rec.SushiComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
                .ToList();
            }
        }
        public SushiViewModel GetElement(SushiBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractSushiBarDatabase())
            {
                var sushi = context.Sushi
                .Include(rec => rec.SushiComponents)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.SushiName.Equals(model.SushiComponents) || rec.Id == model.Id);
                return sushi != null ?
                new SushiViewModel
                {
                    Id = sushi.Id,
                    SushiName = sushi.SushiName,
                    Price = sushi.Price,
                    SushiComponents = sushi.SushiComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(SushiBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Sushi sushi = CreateModel(model, new Sushi());
                        context.Sushi.Add(sushi);
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
        public void Update(SushiBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Sushi.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
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
        public void Delete(SushiBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                Sushi element = context.Sushi.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Sushi.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Sushi CreateModel(SushiBindingModel model, Sushi sushi) 
        {
            sushi.SushiName = model.SushiName;
            sushi.Price = model.Price;
            return sushi;
        }
        private Sushi CreateModel(SushiBindingModel model, Sushi sushi, AbstractSushiBarDatabase context)
        {
            sushi.SushiName = model.SushiName;
            sushi.Price = model.Price;
            if (model.Id.HasValue)
            {
                var sushiComponents = context.SushiComponents.Where(rec =>
               rec.SushiId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.SushiComponents.RemoveRange(sushiComponents.Where(rec =>
               !model.SushiComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in sushiComponents)
                {
                    updateComponent.Count =
                   model.SushiComponents[updateComponent.ComponentId].Item2;
                    model.SushiComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var sc in model.SushiComponents)
            {
                context.SushiComponents.Add(new SushiComponent
                {
                    SushiId = sushi.Id,
                    ComponentId = sc.Key,
                    Count = sc.Value.Item2
                });
                context.SaveChanges();
            }
            return sushi;
        }
    }
}
