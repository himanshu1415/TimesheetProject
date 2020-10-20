using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVChttpClient.Models;
namespace MVChttpClient.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<Employee> employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44376/api/");
                var responseTask = client.GetAsync("Employees");
                    responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<Employee>>();
                    readJob.Wait();
                    employee = readJob.Result;
                }
                else
                {
                    //Error response received   
                    employee = Enumerable.Empty<Employee>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
                return View(employee);
        }
    }
}