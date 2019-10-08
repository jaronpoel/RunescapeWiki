using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;

namespace RuneScapeWiki.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Account()
        {
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
