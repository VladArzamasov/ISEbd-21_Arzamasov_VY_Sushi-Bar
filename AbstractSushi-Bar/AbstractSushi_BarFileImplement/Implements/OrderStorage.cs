using System;
using System.Collections.Generic;
using System.Linq;
using AbstractSushi_BarFileImplement.Models;
using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;

namespace AbstractSushi_BarFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton sourse;
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ClientId = (int)model.ClientId;
            order.SushiId = model.SushiId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
        private OrderViewModel CreateModel(Order order)
        {
            Sushi sushi = sourse.Sushi.FirstOrDefault(rec => rec.Id == order.SushiId);
            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                SushiName = sushi.SushiName,
                SushiId = order.SushiId,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
        public OrderStorage()
        {
            sourse = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return sourse.Orders.Select(CreateModel).ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return sourse.Orders
                .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate == model.DateCreate) ||
                 (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date
                 >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date))
                 .Select(CreateModel)
                 .ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var order = sourse.Orders.FirstOrDefault(recOder => recOder.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            int maxId = sourse.Orders.Count > 0 ? sourse.Orders.Max(recOder => recOder.Id) : 0;
            var order = new Order { Id = maxId + 1 };
            sourse.Orders.Add(CreateModel(model, order));
        }
        public void Update(OrderBindingModel model)
        {
            var order = sourse.Orders.FirstOrDefault(recOder => recOder.Id == model.Id);
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            CreateModel(model, order);
        }
        public void Delete(OrderBindingModel model)
        {
            var order = sourse.Orders.FirstOrDefault(recOrder => recOrder.Id == model.Id);

            if (order != null)
            {
                sourse.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }
    }
}
