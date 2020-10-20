﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCAuthClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCAuthClient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(Userlogin user)
        {
            string token = GetToken("https://localhost:44353/api/token", user);
            // string token = GetToken("http://52.191.222.87/api/Token", user);
            if (token != null)
            {
                return RedirectToAction("Index", "Login", new { name = token });
            }
            else
            {
                ViewBag.invalid = "UserId or Password invalid";
                return View();
            }
        }
        static string GetToken(string url, Userlogin user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
