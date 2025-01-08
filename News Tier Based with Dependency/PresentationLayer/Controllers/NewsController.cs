using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Web.Http;

namespace PresentationLayer.Controllers
{
    public class NewsController : ApiController
    {
        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO n)
        {
            NewsService.Create(n);
            return Request.CreateResponse(HttpStatusCode.OK,"News Created");
        }

        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage GetAll()
        {
            var news = NewsService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/GetNews/{id}")]
        public HttpResponseMessage GetNews(int id)
        {
            var news = NewsService.GetNews(id);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            NewsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "News Deleted");
        }

        [HttpPut]
        [Route("api/news/update/{id}")]
        public HttpResponseMessage Update(int id, NewsDTO n)
        {
            n.Id = id;  
            NewsService.Update(n);
            return Request.CreateResponse(HttpStatusCode.OK, "News Updated");
        }

        [HttpGet]
        [Route("api/news/NewsByTitle/{title}")]

        public HttpResponseMessage NewsByTitle(string title)
        {
            var news = NewsService.NewsByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, news);

        }

        [HttpGet]
        [Route("api/news/NewsByCategory/{category}")]

        public HttpResponseMessage NewsByCategory(string category)
        {
            var news = NewsService.NewsByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, news);

        }

        [HttpGet]
        [Route("api/news/NewsByDate/{date}")]

        public HttpResponseMessage NewsByDate(DateTime date)
        {
            var news = NewsService.NewsByDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/NewsByDateCat/{category}/{date}")]


        public HttpResponseMessage NewsByDateCat(DateTime date, string category)
        {
            var news = NewsService.NewsByDateCat(date,category);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }

        [HttpGet]
        [Route("api/news/NewsByDateTitle/{date}/{title}")]

        public HttpResponseMessage NewsByDateTitle(DateTime date, string title)
        {
            var news = NewsService.NewsByDateCat(date, title);
            return Request.CreateResponse(HttpStatusCode.OK, news);
        }
    }
}
