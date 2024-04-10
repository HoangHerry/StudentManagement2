using Microsoft.Owin.BuilderProperties;
using PagedList;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        public ActionResult Index(int? page, int? pageSize)
        {
            Session.Remove("Major");
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
                CourseInformationManagement courseInformation = new CourseInformationManagement();
                List<ICourse> obj = courseInformation.GetCourses(string.Empty, string.Empty);
                return View(obj.ToPagedList((int)page, (int)pageSize));
            }
            return RedirectToAction("Login", "Indentity");
        }
        public ActionResult GetClassBeLongsToCourses(string idCourse, int? page, int? pageSize)
        {
            if (Session["role"] != null)
            {
                Session["idCourse"] = idCourse;
                if (page == null)
                {
                    page = 1;
                }
                if (pageSize == null)
                {
                    pageSize = 5;
                }
                CourseInformationManagement courseInformation = new CourseInformationManagement();
                List<ClassBeLongsToCourse> obj = courseInformation.GetClassBeLongsToCourses(idCourse);
                return View(obj.ToPagedList((int)page, (int)pageSize));
            }
            return RedirectToAction("Login", "Indentity");
        }
        [HttpPost]
        public ActionResult AddClassById(string idCourse, string idClass)
        {

            CourseInformationManagement courseInformation = new CourseInformationManagement();

            ClassBeLongsToCourse classBeLongsToCourse = new ClassBeLongsToCourse(idCourse, idClass);

            courseInformation.AddClassToCourse(classBeLongsToCourse);

            return RedirectToAction("GetClassBeLongsToCourses", new { idCourse = idCourse });

        }
    }
}