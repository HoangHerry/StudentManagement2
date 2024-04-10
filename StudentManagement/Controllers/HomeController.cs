using PagedList;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["role"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Indentity");
        }
    }
}



