using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagement.Controllers
{
    public class IndentityController : Controller
    {
        public ActionResult Login()
        {
            Session.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string password, bool rememberMe = false)
        {
            Session["role"] = 0;
            Identity identity = new Identity();
            bool checkAccount = identity.IsValid(user, password);
            if (checkAccount)
            {
                int role = identity.GetRolesForUser(user);
                Session["role"] = identity.GetRolesForUser(user);
                Session["user"] = user;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }
        }
        public ActionResult Logout(string user, string password, bool rememberMe = false)
        {
            return RedirectToAction("Login", "Indentity");

        }

    }
}