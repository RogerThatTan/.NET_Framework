using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPManagement.Auth;
using TRPManagement.DTOs;
using TRPManagement.EF;

namespace TRPManagement.Controllers
{
    [LoginAccess]
    public class ProgramController : Controller
    {
        MidPracticeTaskEntities db = new MidPracticeTaskEntities();

        [AllowAnonymous]
        public ActionResult ProgramList()
        {   
            var channel = db.Channels.ToList();
            var programs = db.Programs.ToList();
            ViewBag.Channel = channel;
            return View(channel);   //dont work with convert
        }


        [HttpGet]
        [AdminAccess]
        public ActionResult CreateProgram()
        {   
            ViewBag.channels = db.Channels.ToList();
            return View(new ProgramDTO());

        }

        [HttpPost]
        [AdminAccess]
        public ActionResult CreateProgram(ProgramDTO programDTO)
        {
            bool isProgramExist = (from p in db.Programs
                                   where p.ProgramName == programDTO.ProgramName && p.ChannelId ==              programDTO.ChannelId
                                   select p).Any();

            if (isProgramExist)
            {
                ModelState.AddModelError("ProgramName", "Program Name already exists");
                //return View(programDTO);
            }

            if (ModelState.IsValid)
            {
                db.Programs.Add(ConvertDTO.Convert(programDTO));
                db.SaveChanges();
                TempData["msg"] = "Program Added Successfully";
                return RedirectToAction("ProgramList");
            }

            //ViewBag.channels = ConvertDTO.Convert(db.Channels.Include("Programs").ToList());
            ViewBag.channels = db.Channels.ToList();
            return View(programDTO);

        }

        [HttpGet]
        [AdminAccess]
        public ActionResult EditProgram(int id)
        {
            var program = db.Programs.Find(id);
            ViewBag.channels = ConvertDTO.Convert(db.Channels.ToList());
            ViewBag.channelname = db.Channels.Find(program.ChannelId).ChannelName;
            return View(ConvertDTO.Convert(program));

        }

        [HttpPost]
        [AdminAccess]

        public ActionResult EditProgram(ProgramDTO programDTO) 
        { 
            var program = db.Programs.Find(programDTO.ProgramId);
            program.ProgramName = programDTO.ProgramName;
            program.TRPScore = programDTO.TRPScore;
            program.ChannelId = programDTO.ChannelId;
            program.AirTime = programDTO.AirTime;
            db.SaveChanges();
            TempData["msg"] = "Program Updated Successfully";
            return RedirectToAction("ProgramList");

        }

        [HttpGet]
        [AdminAccess]
        public ActionResult DeleteProgram(int id)
        {
            var program = db.Programs.Find(id);
            ViewBag.channelname = db.Channels.Find(program.ChannelId).ChannelName;
            return View(ConvertDTO.Convert(program));

        }

        [HttpPost]
        [AdminAccess]
        public ActionResult DeleteProgram(ProgramDTO programDTO, string reply)
        {
            var program = db.Programs.Find(programDTO.ProgramId);
            if(reply == "Yes")
            {
                db.Programs.Remove(program);
                db.SaveChanges();
                TempData["msg"] = "Program Deleted Successfully";
                return RedirectToAction("ProgramList");
            }
            TempData["msg"] = "Program Deletion Cancelled";
            return RedirectToAction("ProgramList");

        }

        [HttpGet]
        [AllowAnonymous]

        public ActionResult FilterByChannel(int id)
        {
            var channel = (from c in db.Channels
                           where c.ChannelId == id
                           select c).FirstOrDefault();
            var programs = (from p in db.Programs
                            where p.ChannelId == id
                            select p).ToList();
            ViewBag.ChannelName = channel.ChannelName;
            return View(ConvertDTO.Convert(programs));

        }

        [AllowAnonymous]

        public ActionResult Search(string search)
        {
           if(decimal.TryParse(search, out decimal TRPScore))
            {
                var programs = (from p in db.Programs
                                where p.TRPScore == TRPScore
                                select p).ToList();
                return View(ConvertDTO.Convert(programs));
            }
            else
            {
                var programs = (from p in db.Programs
                                where p.ProgramName.Contains(search)
                                select p).ToList();
                return View(ConvertDTO.Convert(programs));
            }

        }

    }
}