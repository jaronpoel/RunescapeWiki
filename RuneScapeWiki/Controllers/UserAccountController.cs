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
    public class UserAccountController : Controller
    {
        private readonly IUserLogic UserLogic;

        public UserAccountController(IUserContext context)
        {
            UserLogic = new Logic.LogicObjects.UserLogic(context);
        }

        public ActionResult UserAccount()
        {
            return View();
        }

        public ActionResult UpdateAccount()
        {
            return RedirectToAction("NewAccount", "Account");
        }
    }
}
