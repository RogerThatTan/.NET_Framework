using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using TRPManagement.DTOs;
using TRPManagement.EF;
using TRPManagement.Models;

namespace TRPManagement.Controllers
{
    public class ChannelController : Controller
    {
        MidPracticeTaskEntities db = new MidPracticeTaskEntities();
        
        public ActionResult List()
        {
            var channel = db.Channels.ToList();
            ViewBag.Channels = channel;
            return View(ConvertDTO.Convert(channel));
        }

        [HttpGet]
        public ActionResult FilterByChannel(int ChannelId)
        {
            var channel = (from c in db.Channels
                           where c.ChannelId == ChannelId
                           select c).FirstOrDefault();

            var programs = (from p in db.Programs
                            where p.ChannelId == ChannelId
                            select p).ToList();

            ViewBag.ChannelName = channel.ChannelName;
            return View(ConvertDTO.Convert(programs));
        }









        [HttpGet]
        public ActionResult Create()
        {
            return View(new Channel());
        }

        [HttpPost]
        public ActionResult Create(ChannelDTO channelDTO)
        {
            bool isChannelNameExists = (from c in db.Channels
                                        where c.ChannelName == channelDTO.ChannelName
                                        select c).Any();

            if (isChannelNameExists)
            {
                ModelState.AddModelError("ChannelName", "Channel name must be unique.");
                return View(channelDTO); 
            }

            if (ModelState.IsValid)
            {
                var channel = ConvertDTO.Convert(channelDTO);
                db.Channels.Add(channel);
                db.SaveChanges();
                TempData["msg"] = "Channel created successfully!";
                return RedirectToAction("List");
            }

            return View(channelDTO);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var channel = db.Channels.Find(id);
            return View(channel);
        }
        [HttpPost]
        public ActionResult Edit(ChannelDTO channelDTO)
        {
            if (ModelState.IsValid)
            {
                var channel = db.Channels.Find(channelDTO.ChannelId);
                channel.ChannelName = channelDTO.ChannelName;
                channel.EstablishedYear = channelDTO.EstablishedYear;
                channel.Country = channelDTO.Country;
                db.SaveChanges();
                TempData["msg"] = "Channel updated successfully!";
                return RedirectToAction("List");
            }
            return View(channelDTO);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var channel = db.Channels.Find(id);
            var programs = (from p in db.Programs
                            where p.ChannelId == id
                            select p).ToList();
            ViewBag.plist = programs;
            return View(ConvertDTO.Convert(channel));
        }
        [HttpPost]
        public ActionResult Delete(ChannelDTO channel, string reply)
        {
            if (reply=="Yes") { 
            var check_programs = (from p in db.Programs
                                  where p.ChannelId == channel.ChannelId
                                  select p).ToList();
            if (check_programs.Count > 0)
            {
                TempData["msg"] = "This channel has programs. Please delete the programs first!";
                return RedirectToAction("List");
            }
            else
            {
                var ch = db.Channels.Find(channel.ChannelId);
                db.Channels.Remove(ch);
                db.SaveChanges();
                TempData["msg"] = "Channel deleted successfully!";
                return RedirectToAction("List");
            }
        }
            return RedirectToAction("List");

        }

    }
}
