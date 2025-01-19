using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Solid_Rec.Controllers
{
    public class PostController : ApiController
    {
        [HttpGet]
        [Route("api/posts")]
        public HttpResponseMessage Posts()
        {
            try
            {
                var data = PostService.Get(); 
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/posts/{id}")]
        public HttpResponseMessage Post(int id)
        {


            try
            {
                var data = PostService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }

        [HttpGet]
        [Route("api/posts/{id}/comments")]
        public HttpResponseMessage PostComments(int id)
        {


            try
            {
                var data = PostService.GetWithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }

        }















    }
}
