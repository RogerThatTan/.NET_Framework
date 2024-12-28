using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetFirstWebApi.Controllers
{
    public class EmployeesDataController : ApiController
    {
        public string[] myEmployees =
        {
            "John Doe",
            "Jane Doe",
            "John Smith",
            "Jane Smith"
        };


        [HttpGet]
        public string[] GetEmployees()    //will return the arrays of employee
        { 
            return myEmployees;
        }

        [HttpGet]
        public string GetEmployeeByIndex(int id) 
        {
            return myEmployees[id];
        }

    }
}
