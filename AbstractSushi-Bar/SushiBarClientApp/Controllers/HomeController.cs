﻿using AbstractSushi_BarBusinessLogic.BindingModels;
using AbstractSushi_BarBusinessLogic.ViewModels;
using SushiBarClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SushiBarClientApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public IActionResult Index()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return
            View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}"));
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }
        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
            && !string.IsNullOrEmpty(fio))
            {
                //прописать запрос
                Program.Client.ClientFIO = fio;
                Program.Client.Email = login;
                Program.Client.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore
        = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ??
            HttpContext.TraceIdentifier
            });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
                if (Program.Client == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
            && !string.IsNullOrEmpty(fio))
            {
                APIClient.PostRequest("api/client/register", new
                ClientBindingModel
                {
                    ClientFIO = fio,
                    Email = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Sushis =
            APIClient.GetRequest<List<SushiViewModel>>("api/main/getproductlist");
            return View();
        }
        [HttpPost]
        public void Create(int sushi, int count, decimal sum)
        {
            if (count == 0 || sum == 0)
            {
                return;
            }
            APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
            {
                ClientID = (int)Program.Client.Id,
                SushiId = sushi,
                Count = count,
                Sum = sum
            });
            Response.Redirect("Index");
        }
        [HttpPost]
        public decimal Calc(decimal count, int sushi)
        {
            SushiViewModel sush =
        APIClient.GetRequest<SushiViewModel>($"api/main/getproduct?productId={sushi}");
            return count * sush.Price;
        }
    }
}
