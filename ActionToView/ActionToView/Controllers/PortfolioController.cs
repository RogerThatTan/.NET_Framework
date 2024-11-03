using ActionToView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionToView.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Education()
        {   

            Degree d1 = new Degree()
            {
                Title = "BSc in CS",
                Ins = "AIUB",
                Result = "3.98",
                Year = "2024"
            };

            Degree d2 = new Degree()
            {
                Title = "A-Level",
                Ins = "DPS STS School",
                Result = "4.00",
                Year = "2020"
            };

            Degree d3 = new Degree()
            {
                Title = "O-Level",
                Ins = "DPS STS School",
                Result = "4.00",
                Year = "2018"
            };

            Degree[] degress = new Degree[] { d1, d2, d3 };
            ViewBag.Degrees = degress;


            // ViewData Example

            Degree d4 = new Degree()
            {
                Title = "BSc in EEE",
                Ins = "AIUB",
                Result = "3.98",
                Year = "2024"
            };

            Degree d5 = new Degree()
            {
                Title = "A-Level",
                Ins = "Sunny Dale",
                Result = "4.00",
                Year = "2020"
            };

            Degree d6 = new Degree()
            {
                Title = "O-Level",
                Ins = "Sunny Dale",
                Result = "4.00",
                Year = "2018"
            };

            Degree[] degress2 = new Degree[] { d4, d5, d6 };
            ViewData["Degrees2"] = degress2;
            ViewData["length"] = degress2.Length;
            return View();
        }

        public ActionResult Qualification()
        {
            bool hasQualification = false;
            //
            //
            //
            //

            if (hasQualification)
            {
                return View();
            }
            else
            {
                TempData["msg"] = "You don't have the extra qualification to visit this page, Redirecting to Education Page.";
                return RedirectToAction("Education","Portfolio");
            }
        }

        //Model Binding Example
        public ActionResult References() {

            Refree r1 = new Refree()
            {
                Name = "Mr. X",
                Ins = "AIUB",
                Email = "E1",
            };

            Refree r2 = new Refree()
            {
                Name = "Mr. Y",
                Ins = "AIUB",
                Email = "E2",
            };

            Refree r3 = new Refree()
            {
                Name = "Mr. Z",
                Ins = "AIUB",
                Email = "E3",
            };

            Refree[] refrees = new Refree[] { r1, r2, r3 };
            return View(refrees);

        }
    }
}