using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;

namespace RuneScapeWiki.Controllers
{
    public class NewAccountController : Controller
    {
        public ActionResult NewAccount()
        {
            return View();
        }

        public ActionResult ToAccount()
        {
            return RedirectToAction("Account", "Account");
        }
    }
}
