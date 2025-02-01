using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRP.DTOs;
using TRP.EF;

namespace TRP.Controllers
{
    public class ProgramController : Controller
    {
        TRPEntities database = new TRPEntities();
        // GET: Program

        public static Program Convert(ProgramDTO pr)
        {
            return new Program()
            {
                ProgramId = pr.ProgramId,
                ProgramName = pr.ProgramName,
                TRPScore = pr.TRPScore,
                ChannelId = pr.ChannelId,
                AirTime = pr.AirTime
            };
        }
        public static ProgramDTO Convert(Program pr)
        {

            return new ProgramDTO()
            {
                ProgramId = pr.ProgramId,
                ProgramName = pr.ProgramName,
                TRPScore = pr.TRPScore,
                ChannelId = pr.ChannelId,
                AirTime = pr.AirTime
            };
        }
        public static List<ProgramDTO> Convert(List<Program> data)
        {
            var list = new List<ProgramDTO>();
            foreach (var pr in data)
            {
                list.Add(Convert(pr));
            }
            return list;
        }



        [HttpGet]
        public ActionResult AddProgram(int chId)
        {
            var programDto = new ProgramDTO
            {
                ChannelId = chId
            };

            // Fetch channel details if you need to display them on the page
            var channel = database.Channels.Find(chId);
            ViewBag.ChannelName = channel?.ChannelName;

            return View(programDto);
        }

        [HttpPost]
        public ActionResult AddProgram(ProgramDTO pr)
        {
            if (ModelState.IsValid)
            {
                database.Programs.Add(Convert(pr));
                database.SaveChanges();
                TempData["Mgs"] = "Program created successfully!";
                return RedirectToAction("ListP", new { channelId = pr.ChannelId });
            }
            return View(pr);
        }



        [HttpGet]
        public ActionResult EditP(int id)
        {
            var program = database.Programs.Find(id);
            var programDto = Convert(program);
            ViewBag.ChannelId = programDto.ChannelId;
            return View(programDto);
        }

        [HttpPost]
        public ActionResult EditP(ProgramDTO pr)
        {
            if (ModelState.IsValid)
            {
                var program = database.Programs.Find(pr.ProgramId);

                // Update program properties
                program.ProgramName = pr.ProgramName;
                program.TRPScore = pr.TRPScore;
                program.AirTime = pr.AirTime;

                database.SaveChanges();
                TempData["Mgs"] = "Program updated successfully!";
                return RedirectToAction("ListP", new { channelId = pr.ChannelId });
            }
            return View(pr);
        }


        public ActionResult ListP(int channelId)
        {
            var programs = database.Programs.Where(p => p.ChannelId == channelId).ToList();

            ViewBag.ChannelName = database.Channels.Find(channelId)?.ChannelName; // For displaying channel name
            ViewBag.ChannelId = channelId; // Store the channel ID for potential use in the view
            return View(Convert(programs));
        }



        [HttpGet]
        public ActionResult DeleteP(int id)
        {
            var program = database.Programs.Find(id);
            if (program == null)
            {
                TempData["Msg"] = "Program not found!";
                return RedirectToAction("ListP", new { channelId = program.ChannelId });
            }

            var programDto = Convert(program);
            ViewBag.ProgramId = programDto.ProgramId; // For use in the view
            ViewBag.ChannelId = programDto.ChannelId; // Pass ChannelId to redirect back after deletion
            return View(programDto);
        }

        [HttpPost]
        public ActionResult DeleteP(int ProgramId, string dcsn, int channelId)
        {
            if (dcsn.Equals("Yes"))
            {
                var program = database.Programs.Find(ProgramId);
                if (program != null)
                {
                    database.Programs.Remove(program);
                    database.SaveChanges();
                    TempData["Msg"] = "Program deleted successfully!";
                }
            }
            return RedirectToAction("ListP", new { channelId = channelId });
        }


        [HttpGet]
        public ActionResult DetailsP(int id)
        {
            var program = database.Programs.Find(id);

            if (program == null)
            {
                TempData["Msg"] = "Program not found!";
                return RedirectToAction("ListP");
            }

            var programDto = Convert(program);
            ViewBag.ChannelId = programDto.ChannelId; // Pass ChannelId for back link
            return View(programDto);
        }





    }
}