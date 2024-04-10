using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Drawing.Printing;
using System.Web.UI;
using Microsoft.Owin.BuilderProperties;
using System.Security.Principal;
using System.Web.Helpers;
using System.Xml.Linq;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
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
                StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
                List<IStudent> obj = studentInformationManagement.GetStudents(string.Empty, string.Empty);
                return View(obj.ToPagedList((int)page, (int)pageSize));
            }
            return RedirectToAction("Login", "Indentity");

        }
        public ActionResult GetStudentbyID(string idStudent)
        {
            Session.Remove("Major");
            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
            List<IStudent> obj = studentInformationManagement.GetStudents(idStudent,string.Empty);
            return View("Index", obj.ToPagedList(1, 1));
        }
        public ActionResult GetStudentsByMajor(string idMajor, int? page, int? pageSize)
        {
            Session["Major"] = idMajor;
            if (string.IsNullOrEmpty(idMajor))
            {
                return RedirectToAction("Index");
            }

            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();

            List<IStudent> obj = studentInformationManagement.GetStudents(string.Empty, idMajor);

            int pageNumber = page ?? 1;
            int pageSizeNumber = pageSize ?? 5;

            return View("ViewStudentByMajor", obj.ToPagedList(pageNumber, pageSizeNumber));
        }


        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string idStudent, string idMajor, string name, DateTime birthday, string sex, string phonenumber, string address, string email, int idAccount)
        {
            if (ModelState.IsValid)
            {
                Student student = new Student(idStudent, idMajor, name, birthday, sex, phonenumber, address, email, idAccount);

                StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
                studentInformationManagement.AddStudent(student);

                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id)
        {
            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
            List<IStudent> obj = studentInformationManagement.GetStudents(id, string.Empty);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(string idStudent, string idMajor, string name, DateTime birthday, string sex, string phonenumber, string address, string email, int idAccount)
        {
            Student student = new Student(idStudent, idMajor, name, birthday, sex, phonenumber, address, email, idAccount);
            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
            studentInformationManagement.UpdateStudent(student);
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(string id)
        {
            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
            List<IStudent> obj = studentInformationManagement.GetStudents(id, string.Empty);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id)
        {
            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
            List<IStudent> obj = studentInformationManagement.GetStudents(id,string.Empty);
            return View(obj.FirstOrDefault());

        }
        [HttpPost]
        public ActionResult Delete(string idStudent, string idMajor, string name, DateTime birthday, string sex, string phonenumber, string address, string email, int idAccount)
        {
            Student student = new Student(idStudent, idMajor, name, birthday, sex, phonenumber, address, email, idAccount);
            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
            studentInformationManagement.DeleteStudent(student);
            return RedirectToAction("Index");
            

        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult GetRegisteredClassOfStudent(int? page, int? pageSize)
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
                RegisteredClass registeredClass = new RegisteredClass();
                List<Class_Student> obj = registeredClass.GetStudentBelongClass(string.Empty);
                return View(obj.ToPagedList((int)page, (int)pageSize));
            }
            return RedirectToAction("Login", "Indentity");
        }
        public ActionResult GetRegisteredClassOfStudentbyIDClass(string idClass, int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 5;
            }
            RegisteredClass registeredClass = new RegisteredClass();
            List<Class_Student> obj = registeredClass.GetStudentBelongClass(idClass);
            return View("GetRegisteredClassOfStudent", obj.ToPagedList((int)page, (int)pageSize));
        }
        public ActionResult getClassesByIdCourse(string idStudent,string idCourse, int? page, int? pageSize)
        {
            if (Session["role"] != null)
            {
                Session["idCourse"] = idCourse;
                Session["idStudent"] = idStudent;
                if (page == null)
                {
                    page = 1;
                }
                if (pageSize == null)
                {
                    pageSize = 5;
                }
                RegisteredClass registeredClass = new RegisteredClass();
                List<ClassBeLongsToCourse> obj = registeredClass.getClassesByIdCourse(idCourse);
                return View(obj.ToPagedList((int)page, (int)pageSize));
            }
            return RedirectToAction("Login", "Indentity");
        }
        public ActionResult RegisterClassforStudent(string idClass, string idStudent)
        {
            if (ModelState.IsValid)
            {
                Class_Student class_Student = new Class_Student(idClass, idStudent);

                RegisteredClass registeredClass = new RegisteredClass();
                registeredClass.addClassforStudent(class_Student);

                return RedirectToAction("GetRegisteredClassOfStudent");
            }
            return RedirectToAction("GetRegisteredClassOfStudent");
        }

    }
}