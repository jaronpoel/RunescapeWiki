using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;

namespace RuneScapeWiki.Controllers
{
    public class MonsterController : Controller
    {
        private readonly IMonsterLogic MonsterLogic;
        private readonly ITipLogic TipLogic;

        public MonsterController(IMonsterContext context, ITipContext context2)
        {
            MonsterLogic = new Logic.LogicObjects.MonsterLogic(context);
            TipLogic = new Logic.LogicObjects.TipLogic(context2);
        }

        public ActionResult Monster()
        {
            ViewBag.Monster = MonsterLogic.GetMonsterByID((int)HttpContext.Session.GetInt32("id"));
            ViewBag.Tip = TipLogic.GetTipByMonsterID((int)HttpContext.Session.GetInt32("id"));
            return View();
        }
    }
}
