using MidExam.DTOs;
using MidExam.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidExam.Controllers
{
    public class LoginController : Controller
    {
        MidExamEntities2 db = new MidExamEntities2();
        [HttpGet]
        public ActionResult LogPage()
        {
            return View(new LoginDTO());
        }

        [HttpPost]
        public ActionResult LogPage(LoginDTO log)
        {
            var user = (from u in db.Users
                        where u.Name == log.Name && u.Password == log.Name
                        select u).SingleOrDefault();
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("BillList", "Admin");
            }
            else
            {
                TempData["msg"] = "User Not Found";
                return View(log);
            }
        }
    }
}