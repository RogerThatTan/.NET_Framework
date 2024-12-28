using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPManagement.DTOs;
using TRPManagement.EF;

namespace TRPManagement.Controllers
{
    public class LoginController : Controller
    {   
        MidPracticeTaskEntities db = new MidPracticeTaskEntities();
        [HttpGet]
        public ActionResult LogPage()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult LogPage(LoginDTO log)
        {
            var user = (from u in db.Users 
                       where u.UserName == log.UserName && u.Password == log.Password
                       select u).SingleOrDefault();
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("ProgramList", "Program");
            }
            else
            {
                TempData["msg"] = "User Not Found";
                return View(log);
            }
        }
    }
}