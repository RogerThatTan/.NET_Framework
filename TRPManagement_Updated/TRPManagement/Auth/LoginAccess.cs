using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TRPManagement.Auth
{
    public class LoginAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["user"];
            if(user == null)
            {
                return false;
            }
            return true;

        }
    }
}