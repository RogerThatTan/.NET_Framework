using IntroToEF_LINQ.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroToEF_LINQ.Controllers
{
    public class StudentController : Controller
    {   

        TestEntities db = new TestEntities();

        public ActionResult List()
        {
            var data  = db.Students.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Create(Student s) {

            db.Students.Add(s);
            db.SaveChanges();
            TempData["Msg"] = "Student Created";
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var data = db.Students.Find(id);
            if(data != null)
            {
                return View(data);
            }
            TempData["Msg"] = "Student with Id "+id+" Not Found";
            return RedirectToAction("List");

        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var data = db.Students.Find(id);
            if (data != null)
            {
                return View(data);
            }
            TempData["Msg"] = "Student with Id " + id + " Not Found";
            return RedirectToAction("List");

        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var data = db.Students.Find(s.Id);
            data.Name = s.Name;
            data.Cgpa = s.Cgpa;
            db.SaveChanges();
            TempData["Msg"] = "Student Updated";
            return RedirectToAction("List");

            //if (!ModelState.IsValid)
            //{
            //    return View(s); 
            //}
            //if (data != null)
            //{
            //    db.Entry(data).CurrentValues.SetValues(s);
            //    db.SaveChanges();
            //    TempData["Msg"] = "Student Updated";
            //    return RedirectToAction("List");
            //}
            //TempData["Msg"] = "Student with Id " + s.Id + " Not Found";
            //return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            //var data = db.Students.Find(id);
            var data = (from s in db.Students
                        where s.Id == id
                        select s).FirstOrDefault();
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            var data = db.Students.Find(s.Id);
            if (data != null)
            {
                db.Students.Remove(data);
                db.SaveChanges();
                TempData["Msg"] = "Student Deleted";
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        //public ActionResult Delete(Student formObj)
        //{
        //    var exobj = (from s in db.Students
        //                 where s.Id == formObj.Id
        //                 select s).FirstOrDefault();
        //    db.Students.Remove(exobj);
        //    db.SaveChanges();
        //    TempData["Msg"] = "Student Deleted";
        //    return RedirectToAction("List");
        //}




    }
}