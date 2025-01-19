using BLL.Services;
using Solid_Rec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Solid_Rec.Controllers
{
    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("api/login")]
        public HttpResponseMessage Login(LoginModel login)
        {
            try
            {
                var result = AuthService.Authenticate(login.Uname, login.Password);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Invalid Credentials" });

                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message});
            }
        }

    }
}