using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WeatherAPP.Controllers
{
    public class LocationController : ApiController
    {
        [HttpPost]
        [Route("api/location/create")]
        public HttpResponseMessage Create(LocationDTO location)
        {

            var data = LocationService.Create(location);
            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpGet]
        [Route("api/location/get")]
        public HttpResponseMessage Get()
        {
            var locations = LocationService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, locations);
        }

        [HttpGet]
        [Route("api/location/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var location = LocationService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, location);
        }

        [HttpGet]
        [Route("api/location/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var location = LocationService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
        }

        [HttpPost]
        [Route("api/location/update/{id}")]
        public HttpResponseMessage Update(int id,LocationDTO location)
        {
            try
            {
                location.Id = id;
                var data = LocationService.Update(location);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    message = ex.Message
                });
            }

        }

        


    }
}

