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
    public class ListController : Controller
    {
        private readonly IMonsterLogic MonsterLogic;
        private readonly IGameAccountLogic GameAccountLogic;

        public ListController(IMonsterContext context, IGameAccountContext context2)
        {
            MonsterLogic = new Logic.LogicObjects.MonsterLogic(context);
            GameAccountLogic = new Logic.LogicObjects.GameAccountLogic(context2);
        }
        public ActionResult List()
        {
            ViewBag.GameAccount = GameAccountLogic.GetAccountByID((int)HttpContext.Session.GetInt32("id"));
            AllMonsterViewModel ViewModel = new AllMonsterViewModel();
            ViewModel.ListOfMonsters = MonsterLogic.GetAllMonsters();
            return View(ViewModel);
        }
    }
}
