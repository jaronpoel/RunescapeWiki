﻿using System;
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
                    return RedirectToAction("List", "List");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
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

        [HttpPost]
        public IActionResult SignUp(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserLogic.InsertUser(new User
                    {
                        Email = user.Email,
                        Username = user.Username,
                        Password = user.Password
                    });
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return RedirectToAction("Register", "Home");
                }
            }
            return RedirectToAction("Register", "Home");
        }
    }
}
