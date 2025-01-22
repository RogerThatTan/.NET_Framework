using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WeatherAPP.Controllers
{
    public class WeatherController : ApiController
    {
        [HttpPost]
        [Route("api/weather/create")]
        public HttpResponseMessage Create(WeatherLocationDTO weather)
        {
           
         var data = WeatherService.Create(weather);
         if(data) return Request.CreateResponse(HttpStatusCode.OK,"Weather added successfully");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Weather not added");

        }

        [HttpGet]
        [Route("api/weather/get")]
        public HttpResponseMessage Get()
        {
            var data = WeatherService.Get();
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
        }

        [HttpGet]
        [Route("api/weather/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = WeatherService.Get(id);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
        }

        [HttpPost]
        [Route("api/weather/update/{id}")]

        public HttpResponseMessage Update(int id,WeatherLocationDTO weather)
        {
            weather.Id = id;
            var data = WeatherService.Update(weather);
            if (data) return Request.CreateResponse(HttpStatusCode.OK, "Weather updated successfully");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Weather not updated");
        }


        [HttpGet]
        [Route("api/weather/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = WeatherService.Delete(id);
            if (data) return Request.CreateResponse(HttpStatusCode.OK, "Weather deleted successfully");
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Weather not deleted");
        }

        [HttpGet]
        [Route("api/weather/search/{id}")]
        public HttpResponseMessage SearchByLocation(int id)
        {
            var data = WeatherService.SearchByLocation(id);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
        }

        [HttpGet]
        [Route("api/weather/forecast/{locationId}")]
        public HttpResponseMessage GetForecastsForNext7Days(int locationId)
        {
            var data = WeatherService.GetForecastsForNext7Days(locationId);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
        }

        [HttpGet]
        [Route("api/weather/current/{locationId}")]
        public HttpResponseMessage CurrentWeather(int locationId)
        {
            var data = WeatherService.CurrentWeather(locationId);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
        }

        [HttpGet]
        [Route("api/weather/alert/{locationId}")]
        public HttpResponseMessage Alert(int locationId)
        {
            var data = WeatherService.Alert(locationId);
            if (data != null) return Request.CreateResponse(HttpStatusCode.OK, data);
            return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
        }
    }
}
