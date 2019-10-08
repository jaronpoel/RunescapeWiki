using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;


namespace RuneScapeWiki.Controllers
{
    public class RegisterenController : Controller
    {
        [HttpGet]
        public ActionResult Registeren()
        {
            return View();
        }

        public ActionResult Verify(Users user)
        {
            return View();
        }
    }
}
