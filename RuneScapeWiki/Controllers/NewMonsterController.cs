using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;

namespace RuneScapeWiki.Controllers
{
    public class NewMonsterController : Controller
    {
        public ActionResult NewMonster()
        {
            return View();
        }

        public ActionResult ToList()
        {
            return RedirectToAction("List", "List");
        }
    }
}
