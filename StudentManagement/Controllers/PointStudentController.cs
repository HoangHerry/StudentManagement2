using PagedList;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class PointStudentController : Controller
    {
        public ActionResult Index(int? page, int? pageSize)
        {
            if (Session["role"] != null)
            {
                if (page == null)
                {
                    page = 1;
                }
                if (pageSize == null)
                {
                    pageSize = 5;
                }
                PointStudentManagement pointStudentManagement = new PointStudentManagement();
                List<PointStudent> obj = pointStudentManagement.GetStudents(string.Empty);
                return View(obj.ToPagedList((int)page, (int)pageSize));
            }
            return RedirectToAction("Login", "Indentity");

        }
    }
}