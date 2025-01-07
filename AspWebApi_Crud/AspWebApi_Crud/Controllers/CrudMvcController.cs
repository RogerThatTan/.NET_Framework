using AspWebApi_Crud.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace AspWebApi_Crud.Controllers
{
    public class CrudMvcController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {   
            List<Employee> emp_list = new List<Employee>();
            client.BaseAddress = new Uri("https://localhost:44304/api/crudapi");
            var response = client.GetAsync("CrudApi");  //controller name
            response.Wait();


            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var read = test.Content.ReadAsAsync<List<Employee>>();
                read.Wait();
                emp_list = read.Result;
            }

            return View(emp_list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            client.BaseAddress = new Uri("https://localhost:44304/api/crudapi");
            var response = client.PostAsJsonAsync<Employee>("CrudApi", emp);
            response.Wait();


            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");
        }
    }
}