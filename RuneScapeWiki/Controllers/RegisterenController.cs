using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using RuneScapeWiki.Models;


namespace RuneScapeWiki.Controllers
{
    public class RegisterenController : Controller
    {
        public ActionResult Registeren()
        {
            return View();
        }
    }
}
