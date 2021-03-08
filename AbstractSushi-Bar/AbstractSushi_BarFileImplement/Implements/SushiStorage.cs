using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushi_BarFileImplement.Implements
{
    public class SushiStorage : ISushiStorage
    {
        private readonly FileDataListSingleton source;
        public SushiStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<SushiViewModel> GetFullList()
        {
            return source.Sushi.Select(CreateModel).ToList();
        }
        public List<SushiViewModel> GetFilteredList(SushiBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Sushi.Where(rec => rec.SushiName.Contains(model.SushiName)).Select(CreateModel).ToList();
        }
        public SushiViewModel GetElement(SushiBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var sushi = source.Sushi.FirstOrDefault(rec => rec.SushiName == model.SushiName || rec.Id == model.Id);
            return sushi != null ? CreateModel(sushi) : null;
        }
        public void Insert(SushiBindingModel model)
        {
            int maxId = source.Sushi.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Sushi
            {
                Id = maxId + 1,
                SushiComponents = new Dictionary<int, int>()
            };
            source.Sushi.Add(CreateModel(model, element));
        }
        public void Update(SushiBindingModel model)
        {
            var element = source.Sushi.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(SushiBindingModel model)
        {
            Sushi element = source.Sushi.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Sushi.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Sushi CreateModel(SushiBindingModel model, Sushi sushi)
        {
            sushi.SushiName = model.SushiName;
            sushi.Price = model.Price;
            // удаляем убранные
            foreach (var key in sushi.SushiComponents.Keys.ToList())
            {
                if (!model.SushiComponents.ContainsKey(key))
                {
                    sushi.SushiComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.SushiComponents)
            {
                if (sushi.SushiComponents.ContainsKey(component.Key))
                {
                    sushi.SushiComponents[component.Key] = model.SushiComponents[component.Key].Item2;
                }
                else
                {
                    sushi.SushiComponents.Add(component.Key, model.SushiComponents[component.Key].Item2);
                }
            }
            return sushi;
        }
        private SushiViewModel CreateModel(Sushi sushi)
        {
            return new SushiViewModel
            {
                Id = sushi.Id,
                SushiName = sushi.SushiName,
                Price = sushi.Price,
                SushiComponents = sushi.SushiComponents
.ToDictionary(recPC => recPC.Key, recPC =>
 (source.Components.FirstOrDefault(recC => recC.Id ==
recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
