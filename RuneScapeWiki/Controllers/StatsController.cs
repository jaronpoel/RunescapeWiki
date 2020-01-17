using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using RuneScapeWiki.Models;

namespace RuneScapeWiki.Controllers
{
    public class StatsController : Controller
    {
        private readonly IGameAccountLogic AccountLogic;

        public StatsController(IGameAccountContext context)
        {
            AccountLogic = new Logic.LogicObjects.GameAccountLogic(context);
        }

        public ActionResult Stats()
        {
            ViewBag.GameAccount = AccountLogic.GetAccountByID((int)HttpContext.Session.GetInt32("id"));
            return View();
        }

        /*Update stats */

        public ActionResult UpdateStatsPage()
        {
            ViewBag.GameAccount = AccountLogic.GetAccountByID((int)HttpContext.Session.GetInt32("id"));
            return View();
        }

        public ActionResult UpdateAccountStats(UpdateGameAccountViewModel updatedAccount)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UpdateStatsPage", "Stats");
            }

            GameAccount account = new GameAccount
            {
                Id = (int)HttpContext.Session.GetInt32("id"),
                Name = updatedAccount.Name,
                Attack = updatedAccount.Attack,
                Defence = updatedAccount.Defence,
                Strength = updatedAccount.Strength,
                Slayer = updatedAccount.Slayer
            };
            AccountLogic.UpdateStats(account);
            return RedirectToAction("Stats", "Stats");
        }
    }
}
