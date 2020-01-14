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

        public ActionResult UpdateStats(GameAccount account)
        {
            AccountLogic.UpdateStats(account);
            return View();
        }


    }
}
