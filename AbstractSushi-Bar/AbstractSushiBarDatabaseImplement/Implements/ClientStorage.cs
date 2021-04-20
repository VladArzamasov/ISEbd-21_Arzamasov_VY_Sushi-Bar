﻿using System;
using System.Collections.Generic;
using System.Text;
using AbstractSushi_BarBusinessLogic.Interfaces;
using AbstractSushi_BarBusinessLogic.ViewModels;
using AbstractSushi_BarBusinessLogic.BindingModels;
using System.Linq;
using AbstractSushiBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractSushiBarDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Clients
                .Select(CreateModel).ToList();
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractSushiBarDatabase())
            {
                return context.Clients
                    .Where(rec => rec.ClientFIO.Contains(model.ClientFIO) || (rec.Email.Equals(model.Email) && rec.Password.Equals(model.Password)))
                    .Select(CreateModel).ToList();
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractSushiBarDatabase())
            {
                var client = context.Clients
                    .FirstOrDefault(rec => rec.Email.Equals(model.Email) || rec.Id == model.Id);
                return client != null ? CreateModel(client) : null;
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                context.Clients.Add(CreateModel(model, new Client()));
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new AbstractSushiBarDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }

        private ClientViewModel CreateModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                ClientFIO = client.ClientFIO,
                Email = client.Email,
                Password = client.Password
            };
        }
    }
}
