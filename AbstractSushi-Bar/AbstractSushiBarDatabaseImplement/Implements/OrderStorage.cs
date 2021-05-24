using System;
using System.Collections.Generic;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarBusinessLogic.BindingModels;
using System.Linq;
using AbstractSushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractSushiBarDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Orders.Include(rec => rec.Sushi).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    SushiName = context.Sushi.FirstOrDefault(r => r.Id == rec.SushiId).SushiName,
                    SushiId = rec.SushiId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
                .ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Orders
                .Include(rec => rec.Sushi)
                .Where(rec => rec.SushiId == model.SushiId)
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    SushiName = rec.Sushi.SushiName,
                    SushiId = rec.SushiId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                })
                .ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractSushiBarDatabase())
            {
                var order = context.Orders
                .Include(rec => rec.Sushi)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    SushiName = order.Sushi.SushiName,
                    SushiId = order.SushiId,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement
                } :
                null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.SushiId = model.SushiId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
