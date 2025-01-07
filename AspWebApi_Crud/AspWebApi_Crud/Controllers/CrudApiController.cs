using AspWebApi_Crud.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Razor;

namespace AspWebApi_Crud.Controllers
{
    public class CrudApiController : ApiController
    {
        web_api_crud_dbEntities db = new web_api_crud_dbEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {

            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

    }
}
