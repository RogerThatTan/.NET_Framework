using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace performance.Controllers
{
    public class NewsController : ApiController
    {
        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage GetAll()
        {   
            var news = NewsService.GetAll();   
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO c)
        {
            NewsService.Create(c);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/news/update/{id}")]
        public HttpResponseMessage Update(int id, NewsDTO n)
        {   
            n.Id = id;
            NewsService.Update(n);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            NewsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/news/filter/{category}")]
        public HttpResponseMessage GetByCategory(string category)
        {
            var news = NewsService.GetByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/filterbyname/{title}")]
        public HttpResponseMessage GetByTitle(string title)
        {
            var news = NewsService.GetByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/filter/{title}/{category}")]
        public HttpResponseMessage GetByTitleAndCategory(string title, string category)
        {
            var news = NewsService.GetByTitleAndCategory(title, category);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/filterbydate/{date}")]
        public HttpResponseMessage GetByDate(DateTime date)
        {
            var news = NewsService.GetByDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }



    }
}
