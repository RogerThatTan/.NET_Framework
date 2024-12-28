using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRPManagement.DTOs;
using TRPManagement.EF;

namespace TRPManagement.Controllers
{
    public class ChannelController : Controller
    {
        MidPracticeTaskEntities db = new MidPracticeTaskEntities();

        public ActionResult ChannelList()
        {
            var channel = db.Channels.ToList();
            return View(ConvertDTO.Convert(channel));
        }

        [HttpGet]
        public ActionResult CreateChannel()
        {
            return View(new ChannelDTO());
        }

        [HttpPost]
        
        public ActionResult CreateChannel(ChannelDTO channelDTO)

        {
            bool isChannelNameExist = (from c in db.Channels
                                       where c.ChannelName == channelDTO.ChannelName
                                       select c).Any();
            if (isChannelNameExist)
            {
                ModelState.AddModelError("ChannelName", "Channel Name already exists");
                return View(channelDTO);
            }
        if(ModelState.IsValid)
        {
            var channel = ConvertDTO.Convert(channelDTO);
            db.Channels.Add(channel);
            db.SaveChanges();
            TempData["msg"] = "Channel Added Successfully";
            return RedirectToAction("ChannelList");
        }
            return View(channelDTO);
        }



        [HttpGet]
        public ActionResult EditChannel(int id)
        {
            var channel = db.Channels.Find(id);
            return View(channel);
        }

        [HttpPost]
        public ActionResult EditChannel(ChannelDTO channelDTO)
        {
            if (ModelState.IsValid) 
        { 
            var channel = db.Channels.Find(channelDTO.ChannelId);
            channel.ChannelName = channelDTO.ChannelName;
            channel.EstablishedYear = channelDTO.EstablishedYear;
            channel.Country = channelDTO.Country;
            db.SaveChanges();
            TempData["msg"] = "Channel Updated Successfully";
            return RedirectToAction("ChannelList");
        }
            return View(channelDTO);
        }


        [HttpGet]
        public ActionResult DeleteChannel(int id)
        {   
            var channel = db.Channels.Find(id);
            var Programs = (from p in db.Programs
                           where p.ChannelId == id
                           select p).ToList();
            ViewBag.Programs = Programs;
            return View(ConvertDTO.Convert(channel));
        }

        [HttpPost]
        public ActionResult DeleteChannel(ChannelDTO channelDTO, string reply)
        {
            if(reply == "Yes")
            {
                var check_program =(from p in db.Programs
                                    where p.ChannelId == channelDTO.ChannelId
                                    select p).ToList();
                if (check_program.Count> 0)
                {
                    TempData["msg"] = "Channel has Programs. Can't delete";
                    return RedirectToAction("ChannelList");
                }
                else
                {
                    var channel = db.Channels.Find(channelDTO.ChannelId);
                    db.Channels.Remove(channel);
                    db.SaveChanges();
                    TempData["msg"] = "Channel Deleted Successfully";
                    return RedirectToAction("ChannelList");
                }
            }
            return RedirectToAction("ChannelList");
        }

















    }
}