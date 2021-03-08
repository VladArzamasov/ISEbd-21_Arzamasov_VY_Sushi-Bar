using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractSushi_BarListImplement.Implements
{
    public class SushiStorage : ISushiStorage
    {
        private readonly DataListSingleton source;
        public SushiStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<SushiViewModel> GetFullList()
        {
            List<SushiViewModel> result = new List<SushiViewModel>();
            foreach (var component in source.Sushi)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<SushiViewModel> GetFilteredList(SushiBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<SushiViewModel> result = new List<SushiViewModel>();
            foreach (var sushi in source.Sushi)
            {
                if (sushi.SushiName.Contains(model.SushiName))
                {
                    result.Add(CreateModel(sushi));
                }
            }
            return result;
        }
        public SushiViewModel GetElement(SushiBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var sushi in source.Sushi)
            {
                if (sushi.Id == model.Id || sushi.SushiName == model.SushiName)
                {
                    return CreateModel(sushi);
                }
            }
            return null;
        }
        public void Insert(SushiBindingModel model)
        {
            Sushi tempSushi = new Sushi
            {
                Id = 1,
                SushiComponents = new Dictionary<int, int>()
            };
            foreach (var sushi in source.Sushi)
            {
                if (sushi.Id >= tempSushi.Id)
                {
                    tempSushi.Id = sushi.Id + 1;
                }
            }
            source.Sushi.Add(CreateModel(model, tempSushi));
        }
        public void Update(SushiBindingModel model)
        {
            Sushi tempSushi = null;
            foreach (var sushi in source.Sushi)
            {
                if (sushi.Id == model.Id)
                {
                    tempSushi = sushi;
                }
            }
            if (tempSushi == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempSushi);
        }
        public void Delete(SushiBindingModel model)
        {
            for (int i = 0; i < source.Sushi.Count; ++i)
            {
                if (source.Sushi[i].Id == model.Id)
                {
                    source.Sushi.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
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
                    sushi.SushiComponents[component.Key] =
                    model.SushiComponents[component.Key].Item2;
                }
                else
                {
                    sushi.SushiComponents.Add(component.Key,
                    model.SushiComponents[component.Key].Item2);
                }
            }
            return sushi;
        }
        private SushiViewModel CreateModel(Sushi sushi)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
        Dictionary<int, (string, int)> sushiComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in sushi.SushiComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                sushiComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new SushiViewModel
            {
                Id = sushi.Id,
                SushiName = sushi.SushiName,
                Price = sushi.Price,
                SushiComponents = sushiComponents
            };
        }
    }
}
