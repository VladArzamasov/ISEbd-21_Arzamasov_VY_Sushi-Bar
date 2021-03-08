﻿using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace AbstractSushi_BarBusinessLogic.BusinessLogics
{
    public class SushiLogic
    {
        private readonly ISushiStorage _sushiStorage;
        public SushiLogic(ISushiStorage sushiStorage)
        {
            _sushiStorage = sushiStorage;
        }
        public List<SushiViewModel> Read(SushiBindingModel model)
        {
            if (model == null)
            {
                return _sushiStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SushiViewModel> { _sushiStorage.GetElement(model)
};
            }
            return _sushiStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(SushiBindingModel model)
        {
            var element = _sushiStorage.GetElement(new SushiBindingModel
            {
                SushiName = model.SushiName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть суши с таким названием");
            }
            if (model.Id.HasValue)
            {
                _sushiStorage.Update(model);
            }
            else
            {
                _sushiStorage.Insert(model);
            }
        }
        public void Delete(SushiBindingModel model)
        {
            var element = _sushiStorage.GetElement(new SushiBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _sushiStorage.Delete(model);
        }
    }
}
