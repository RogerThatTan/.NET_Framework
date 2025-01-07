using MyNewAspWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyNewAspWebAPI.Controllers
{
    public class NewApiController : ApiController
    {
        practiceEntities db = new practiceEntities();

        [HttpGet]
        public IHttpActionResult Index()
        {
            List <student> obj = db.students.ToList();
            return Ok(obj);    //returning the list of students and ok refers to status code 200 which is success
        }

        [HttpGet]
        public IHttpActionResult Index(int id)
        {
            var obj = db.students.Where(model => model.std_id == id).FirstOrDefault();
            return Ok(obj);    //returning the list of students depending on id and ok refers to status code 200 which is success
        }

    }
}
