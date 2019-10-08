using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;

namespace RuneScapeWiki.Controllers
{
    public class MonsterController : Controller
    {
        public ActionResult Monster()
        {
            return View();
        }
    }
}
