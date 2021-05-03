﻿using System;
using System.Collections.Generic;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.Enums;
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
                return context.Orders
                    .Include(rec => rec.Sushi)
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .Select(CreateModel)
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
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .Where(rec =>
                    (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date)
                    || (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date)
                    || (model.ClientId.HasValue && rec.ClientId == model.ClientId)
                    || (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status == OrderStatus.Принят)
                    || (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                    .Select(CreateModel)
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
                    .Include(rec => rec.Client)
                    .Include(rec => rec.Implementer)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ? CreateModel(order) : null;
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
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }

                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

                if (order == null)
                {
                    throw new Exception("Заказ не найден");
                }

                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.SushiId = model.SushiId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId;
            order.Sum = model.Sum;
            order.Count = model.Count;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;

            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ClientId = order.ClientId,
                SushiId = order.SushiId,
                ImplementerId = order.ImplementerId,
                ClientFIO = order.Client.ClientFIO,
                SushiName = order.Sushi.SushiName,
                ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status,
                DateCreate = order.DateCreate,
                DateImplement = order?.DateImplement
            };
        }
    }
}
