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
    public class ChannelController : Controller
    {
        MidPracticeTaskEntities db = new MidPracticeTaskEntities();
        
        public ActionResult List()
        {
            var channel = db.Channels.ToList();
            return View(ConvertDTO.Convert(channel));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Channel());
        }

        [HttpPost]
        public ActionResult Create(ChannelDTO channelDTO)
        {
            var channel = ConvertDTO.Convert(channelDTO);
            db.Channels.Add(channel);
            db.SaveChanges();
            return RedirectToAction("List");
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
            var channel = db.Channels.Find(channelDTO.ChannelId);
            channel.ChannelName = channelDTO.ChannelName;
            channel.EstablishedYear = channelDTO.EstablishedYear;
            channel.Country = channelDTO.Country;
            db.SaveChanges();
            TempData["msg"] = "Channel updated successfully!";
            return RedirectToAction("List");
        }

    }
}