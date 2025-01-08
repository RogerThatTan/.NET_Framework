using MidExam.DTOs;
using MidExam.EF;
using MidExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MidExam.Auth.AdminAcess;

namespace MidExam.Controllers
{
  

    public class AdminController : Controller
    {
        MidExamEntities2 db = new MidExamEntities2();


        public ActionResult BillList()
        {
            var bill = db.Bills.ToList();
            return View(ConvertDTO.Convert(bill));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BillDTO());
        }

        [HttpPost]

        public ActionResult Create(BillDTO billDTO)
        {
            if (ModelState.IsValid)
            {
                var bill = ConvertDTO.Convert(billDTO);
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("BillList");
            }
            return View(billDTO);
        }


        [HttpGet]
       

        public ActionResult EditBill(int id)
        {
            var bill = db.Bills.Find(id);
            return View(bill);
        }

        [HttpPost]
     

        public ActionResult EditBill(BillDTO billDTO)
        {
            if (ModelState.IsValid)
            {
                var bill  = db.Bills.Find(billDTO.BillId);
                bill.Amount = billDTO.Amount;
                bill.Date = billDTO.Date;
                bill.Status = billDTO.Status;
                db.SaveChanges();
                TempData["msg"] = "Bill Updated Successfully";
                return RedirectToAction("Billlist");
            }
            return View(billDTO);
        }


        [HttpGet]
        public ActionResult DeleteBill(int id)
        {

            var bills = db.Bills.Find(id);
            return View(bills);
        }

        [HttpPost]
       

        public ActionResult DeleteChannel(BillDTO billDTO, string reply)
        {
            
            if(reply == "Yes")
            {
                var bill = db.Bills.Find(billDTO.BillId);
                db.Bills.Remove(bill);
                db.SaveChanges();
                TempData["msg"] = "Bill Deleted Successfully";
                return RedirectToAction("BillList");
            }
            else
            {
                return RedirectToAction("BillList");
            }
              
         
            
        }





    }
}