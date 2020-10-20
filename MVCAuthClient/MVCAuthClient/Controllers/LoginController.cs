using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCAuthClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCAuthClient.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            Userlogin obj = new Userlogin { Username = "abc", Password = "abc123" };
            using (HttpClient client = new HttpClient())
            {
                var token = GetToken("https://localhost:44353/api/Token/", obj);
                client.BaseAddress = new Uri("https://localhost:44351/api/");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("AdminEmployees").Result;

                string stringData = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<IEnumerable<AdminEmployee>>(stringData);

                return View(data);
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
