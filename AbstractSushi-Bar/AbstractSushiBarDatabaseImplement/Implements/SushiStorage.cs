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
                    .ToList().Select(rec => new SushiViewModel
                    {
                        Id = rec.Id,
                        SushiName = rec.SushiName,
                        Price = rec.Price,
                        SushiComponents = rec.SushiComponents
                            .ToDictionary(recD => recD.ComponentId,
                            recD => (recD.Component?.ComponentName, recD.Count))
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
                    .Where(rec => rec.SushiName
                    .Contains(model.SushiName))
                    .ToList()
                    .Select(rec => new SushiViewModel
                    {
                        Id = rec.Id,
                        SushiName = rec.SushiName,
                        Price = rec.Price,
                        SushiComponents = rec.SushiComponents.ToDictionary(recED => recED.ComponentId, recED => (recED.Component?.ComponentName, recED.Count))
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
                var Sushi = context.Sushi
                    .Include(rec => rec.SushiComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.SushiName == model.SushiName || rec.Id == model.Id);

                return Sushi != null ?
                    new SushiViewModel
                    {
                        Id = Sushi.Id,
                        SushiName = Sushi.SushiName,
                        Price = Sushi.Price,
                        SushiComponents = Sushi.SushiComponents
                            .ToDictionary(recED => recED.ComponentId, recED => (recED.Component?.ComponentName, recED.Count))
                    } :
                    null;
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
                        CreateModel(model, new Sushi(), context);
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

        private Sushi CreateModel(SushiBindingModel model, Sushi Sushi, AbstractSushiBarDatabase context)
        {
            Sushi.SushiName = model.SushiName;
            Sushi.Price = model.Price;

            if (Sushi.Id == 0)
            {
                context.Sushi.Add(Sushi);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                var SushiComponents = context.SushiComponents
                    .Where(rec => rec.SushiId == model.Id.Value)
                    .ToList();

                context.SushiComponents
                    .RemoveRange(SushiComponents
                        .Where(rec => !model.SushiComponents
                            .ContainsKey(rec.ComponentId))
                                .ToList());
                context.SaveChanges();

                foreach (var updateDetail in SushiComponents)
                {
                    updateDetail.Count = model.SushiComponents[updateDetail.ComponentId].Item2;
                    model.SushiComponents.Remove(updateDetail.ComponentId);
                }

                context.SaveChanges();
            }

            foreach (var ed in model.SushiComponents)
            {
                context.SushiComponents.Add(new SushiComponent
                {
                    SushiId = Sushi.Id,
                    ComponentId = ed.Key,
                    Count = ed.Value.Item2
                });
                context.SaveChanges();
            }

            return Sushi;
        }
    }
}
