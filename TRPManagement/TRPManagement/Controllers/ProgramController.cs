using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPManagement.DTOs;
using TRPManagement.EF;
using TRPManagement.Models;

namespace TRPManagement.Controllers
{
    public class ProgramController : Controller
    {
        MidPracticeTaskEntities db = new MidPracticeTaskEntities();
        
        //[HttpGet]
        //public ActionResult Create(int channelId) //this one is for create from the channel list
        //{   

        //    var channelName = (from c in db.Channels
        //                       where c.ChannelId == channelId
        //                       select c.ChannelName).FirstOrDefault();

        //    ViewBag.ChannelId = channelId;
        //    ViewBag.ChannelName = channelName;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(ProgramDTO programDTO) //this one is for create from the channel list
        //{
        //    var program = ConvertDTO.Convert(programDTO);
        //    db.Programs.Add(program);
        //    db.SaveChanges();
        //    TempData["msg"] = "Program added successfully!";
        //    return RedirectToAction("List", "Channel");
        //}

        [HttpGet]
        public ActionResult CreateProgram()
        {
            ViewBag.channels = ConvertDTO.Convert(db.Channels.ToList());
            return View(new Program());
        }

        [HttpPost]
        public ActionResult CreateProgram(ProgramDTO program)
        {
            if (ModelState.IsValid)
            {
                db.Programs.Add(ConvertDTO.Convert(program));
                db.SaveChanges();
                TempData["msg"] = "Program added successfully!";
                return RedirectToAction("ProgramList");
            }

            ViewBag.channels = ConvertDTO.Convert(db.Channels.ToList()); //onek pera dise
            return View(program);
        }



        [HttpGet]
        public ActionResult EditProgram(int id)
        {
            var program = db.Programs.Find(id);
            ViewBag.channels = ConvertDTO.Convert(db.Channels.ToList());
            ViewBag.Channel_Name = db.Channels.Find(program.ChannelId);
            return View(ConvertDTO.Convert(program));
        }

        [HttpPost]
        public ActionResult EditProgram(ProgramDTO programDTO)
        {
            var program = db.Programs.Find(programDTO.ProgramId);
            program.ProgramName = programDTO.ProgramName;
            program.TRPScore = programDTO.TRPScore;
            program.ChannelId = programDTO.ChannelId;
            program.AirTime = programDTO.AirTime;
            db.SaveChanges();
            TempData["msg"] = "Program updated successfully!";
            return RedirectToAction("ProgramList");
        }

        [HttpGet]
        public ActionResult DeleteProgram(int id)
        {
            var program = db.Programs.Find(id);
            ViewBag.Channel_Name = db.Channels.Find(program.ChannelId);
            return View(ConvertDTO.Convert(program));
        }

        [HttpPost]
        public ActionResult DeleteProgram(ProgramDTO program, string reply)
        {
            var program_find = db.Programs.Find(program.ProgramId);
            if (reply.Equals("Yes"))
            {
                db.Programs.Remove(program_find);
                db.SaveChanges();
                TempData["msg"] = "Program deleted successfully!";
                return RedirectToAction("ProgramList");
            }
            TempData["msg"] = "Program deleted unsuccessfull!";
            return RedirectToAction("ProgramList");
        }

        public ActionResult ProgramList()
        {
            var channel = db.Channels.ToList();
            var program = db.Programs.ToList();
            ViewBag.Channels = channel;
            return View(channel);
        }

        public ActionResult Search(string searchTerm)
        {
            var programs = from p in db.Programs
                           select p;

            // Check if searchTerm is numeric (for TRP score)
            if (decimal.TryParse(searchTerm, out decimal trpScore))
            {
                // If it's a valid TRP score, filter by TRP score
                programs = from p in programs
                           where p.TRPScore == trpScore
                           select p;
            }
            else if (!string.IsNullOrEmpty(searchTerm))
            {
                // If it's not a number, assume it's a program name
                programs = from p in programs
                           where p.ProgramName.Contains(searchTerm)
                           select p;
            }

            return View(ConvertDTO.Convert(programs.ToList())); // Assuming ConvertDTO is used for converting entities to DTOs
        }


    }
}