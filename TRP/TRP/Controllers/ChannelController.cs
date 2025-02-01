using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP.DTOs;
using TRP.EF;

namespace TRP.Controllers
{
    public class ChannelController : Controller
    {
        TRPEntities database = new TRPEntities();
        // GET: TRP

        [LoggedUser]
        public static Channel Convert(ChannelDTO ch)
        {
            return new Channel()
            {
                ChannelId = ch.ChannelId,
                ChannelName = ch.ChannelName,
                EstablishedYear = ch.EstablishedYear,
                Country = ch.Country
            };
        }
        public static ChannelDTO Convert(Channel ch)
        {

            return new ChannelDTO()
            {
                ChannelId = ch.ChannelId,
                ChannelName = ch.ChannelName,
                EstablishedYear = ch.EstablishedYear,
                Country = ch.Country
            };
        }
        public static List<ChannelDTO> Convert(List<Channel> data)
        {
            var list = new List<ChannelDTO>();
            foreach (var ch in data)
            {
                list.Add(Convert(ch));
            }
            return list;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ChannelDTO());
        }

        [HttpPost]
        public ActionResult Create(ChannelDTO ch)
        {
            if (ModelState.IsValid)
            {
                database.Channels.Add(Convert(ch));
                database.SaveChanges();
                TempData["Mgs"] = "Channel created successfully!";
                return RedirectToAction("List");
            }
            return View(ch);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = database.Channels.Find(id);
            return View(Convert(data));
        }

        [HttpPost]
        public ActionResult Edit(ChannelDTO ch)
        {
            var data = database.Channels.Find(ch.ChannelId);
            database.Entry(data).CurrentValues.SetValues(Convert(ch));
            database.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Details(int id)
        {
            var data = database.Channels.Find(id);
            var test = data.ChannelName;
            var test2 = data.EstablishedYear;
            var test3 = data.Country;

            return View(Convert(data));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = database.Channels.Find(id);
            var dataP = database.Programs.Where(p => p.ChannelId == id).ToList();
            if (dataP.Count > 0)
            {
                TempData["Mgs"] = "Cannot delete this channel because it has programs!";
                return RedirectToAction("List");
            }
            return View(Convert(data));
        }
        [HttpPost]
        public ActionResult Delete(int ChannelId, string dcsn)
        {
            if (dcsn.Equals("Yes"))
            {
                var data = database.Channels.Find(ChannelId);
                database.Channels.Remove(data);
                database.SaveChanges();
            }
            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            var data = database.Channels.ToList();
            return View(Convert(data));
        }
    }
}