using MyNewAspWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MyNewAspWebAPI.Controllers
{
    public class ConsumeController : Controller
    {
        
        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
        //getting data from API and then showing into the view
           List<student> list = new List<student>(); 
           client.BaseAddress = new Uri("https://localhost:44301/api/NewApi");
           var response = client.GetAsync("NewApi");
           response.Wait();
            
            var test = response.Result;
            if(test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<student>>();
                display.Wait();
                list = display.Result;
            }
            return View(list);
        }
    }
}