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
            ViewBag.User = UserLogic.GetUserByID((int)HttpContext.Session.GetInt32("id"));
            return View();
        }

        public ActionResult UpdateAccount()
        {
            ViewBag.User = UserLogic.GetUserByID((int)HttpContext.Session.GetInt32("id"));
            return View();
        }

        public ActionResult ToUpdateUserAccount()
        {
            return RedirectToAction("UpdateAccount", "UserAccount");
        }

        public IActionResult UpdateUserAccount(UpdateAccountViewModel updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("UpdateAccount", "UserAccount");
            }

            User user = new User
            {
                Id = (int)HttpContext.Session.GetInt32("id"),
                Email = updatedUser.Email,
                Username = updatedUser.UserName,
                Password = updatedUser.Password
            };
            UserLogic.UpdateUser(user);
            return RedirectToAction("UserAccount", "UserAccount");
        }
    }
}
