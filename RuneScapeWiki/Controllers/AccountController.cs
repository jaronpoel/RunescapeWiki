using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Interfaces.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RuneScapeWiki.Models;
using Models;


namespace RuneScapeWiki.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountLogic AccountLogic;

        public AccountController(IAccountContext context)
        {
            AccountLogic = new Logic.LogicObjects.AccountLogic(context);
        }

        public ActionResult Account()
        {
            ViewBag.Account = AccountLogic.GetAccountByID((int)HttpContext.Session.GetInt32("id"));
            return View();
        }

        public ActionResult NewAccount()
        {
            return RedirectToAction("NewAccount", "Account");
        }

        public ActionResult NewStats()
        {
            return RedirectToAction("NewStats", "Stats");
        }
    }
}
