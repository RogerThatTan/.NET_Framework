using MidExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidExam.Auth
{
    public class AdminAcess
    {
        public class AdminAccess : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                var user = (User)httpContext.Session["user"];
                if (user != null && user.Role == 1)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
