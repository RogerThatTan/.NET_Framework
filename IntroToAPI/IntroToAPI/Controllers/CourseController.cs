﻿using IntroToAPI.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroToAPI.Controllers
{
    public class CourseController : ApiController
    {
        Context db = new Context();

        [HttpGet]
        [Route("api/course/getall")]
        public HttpResponseMessage GetAll()
        {
            var data = db.Courses.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/course/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = db.Courses.Find(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, data);
            }
        }

        [HttpPost]
        [Route("api/course/create")]
        public HttpResponseMessage Create(Course c)
        {
            db.Courses.Add(c);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, c);
        }

        [HttpDelete]
        [Route("api/course/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = db.Courses.Find(id);
            if (data != null)
            {
                db.Courses.Remove(data);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, data);
            }
        }


        [HttpPut]
        [Route("api/course/update/{id}")]
        public HttpResponseMessage Update(int id, Course update)
        {
            var exCourse = db.Courses.Find(id);
            if(exCourse != null)
            {
                exCourse.Name = update.Name;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Course updated Successfully");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Course not found");
            }
        }

    }
}
