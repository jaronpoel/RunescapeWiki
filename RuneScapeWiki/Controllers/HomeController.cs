using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;
using Models;
using Interfaces.Contexts;
using Interfaces.Logic;
using Microsoft.AspNetCore.Http;

namespace RuneScapeWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserLogic UserLogic;

        public HomeController(IUserContext context)
        {
            UserLogic = new Logic.LogicObjects.UserLogic(context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult UserLogin(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User local = UserLogic.AuthenticatUser(user.UserName, user.Password);
                    HttpContext.Session.SetInt32("id", local.Id);
                    HttpContext.Session.SetString("username", local.Username);
                    HttpContext.Session.SetInt32("accountid", local.AccountId);
                    return RedirectToAction("List", "List");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "The username or password provided is incorrect");
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        /* Registeren */
        public ActionResult Register()
        {
            return View();
        }
    }
}
