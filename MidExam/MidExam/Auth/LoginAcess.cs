using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidExam.Auth
{
    public class LoginAcess : AuthorizeAttribute  
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["user"];
            if (user == null)
            {
                return false;
            }
            return true;

        }
    }
}
    
