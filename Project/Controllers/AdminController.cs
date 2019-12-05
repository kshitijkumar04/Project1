using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class AdminController : Controller
    {
        project_finalEntities entity = new project_finalEntities();
        // GET: Admin
        public ActionResult AdminSportTournament()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminSportTournament(Sport_tournamentlist add)
        {

            if (ModelState.IsValid)
            {
                entity.Sport_tournamentlist.Add(add);
                entity.SaveChanges();
                return RedirectToAction("AdminLogin", "Home");
            }
            ModelState.AddModelError("", "Invalid input");
            return View();

        }
        public ActionResult AdminCulturalEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCulturalEvent(Cultural_eventlist add)
        {

            if (ModelState.IsValid)
            {
                entity.Cultural_eventlist.Add(add);
                entity.SaveChanges();
                return RedirectToAction("AdminLogin", "Home");
            }
            ModelState.AddModelError("", "Invalid input");
            return View();

        }

        public ActionResult CreateTeam()
        {
            ViewBag.Sport = new SelectList(entity.Sport_tournamentlist, "sports_evid", "sport_name");

            return View();
        }
        public ActionResult _TotTeam(int Sid)
        {
            int a = entity.Sports_reg.Count(d => d.sport_id == Sid);
            int count_teams = 0;
            if (Sid == 1 || Sid == 2)
            {
                count_teams = a / 11;
            }
            else if (Sid == 3)
            {
                count_teams = a / 4;
            }
            Team team = new Team();
            for (int i = 1; i <= count_teams; i++)
            {
                int count = entity.Teams.Count(d => d.sp_id == Sid);
                team.t_no = count + 1;
                team.sp_id = Sid;
                entity.Teams.Add(team);
                entity.SaveChanges();
            }
            int finalcount = entity.Teams.Count(d => d.sp_id == Sid);
            ViewBag.Message = finalcount;
            return PartialView("_TotTeam");
        }

    }
}