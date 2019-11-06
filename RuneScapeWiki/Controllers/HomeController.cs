using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RuneScapeWiki.Models;
using Data;
using Models;

namespace RuneScapeWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository userrepo = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin(User user = null)
        {
            if (!string.IsNullOrEmpty(user.Username) && !string.IsNullOrEmpty(user.Password))
            {
                try
                {
                    userrepo.AuthenticatorUser(user);
                    return ToList();
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult ToList()
        {
            return RedirectToAction("List", "List");
        }
    }
}
