using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTier.Controllers
{
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("api/courses/all")]
        public HttpResponseMessage Get()
        {
            var courses = CourseService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, courses);
        }

        [HttpPost]
        [Route("api/courses/create")]
        public HttpResponseMessage Create(CourseDTO c)
        {
            CourseService.Create(c);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/courses/update")]
        public HttpResponseMessage Update(CourseDTO c)
        {
            CourseService.Update(c);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
