using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Course : ICourse
    {
        private string idCourse;
        private string nameCourse;
        private int numberOfCredit;
        private string idMajor;

        public Course(string idCourse, string nameCourse, int numberOfCredit, string idMajor)
        {
            this.idCourse = idCourse;
            this.nameCourse = nameCourse;
            this.numberOfCredit = numberOfCredit;
            this.idMajor = idMajor;
        }

        public string IdCourse { get => idCourse; set => idCourse = value; }
        public string NameCourse { get => nameCourse; set => nameCourse = value; }
        public int NumberOfCredit { get => numberOfCredit; set => numberOfCredit = value; }
        public string IdMajor { get => idMajor; set => idMajor = value; }
    }
    public class ClassBeLongsToCourse
    {
        private string idCourse;
        private string idClass;

        public ClassBeLongsToCourse(string idCourse, string idClass)
        {
            this.idCourse= idCourse;
            this.idClass = idClass;
        }

        public string IdCourse { get => idCourse; set => idCourse = value; }
        public string IdClass { get => idClass; set => idClass = value; }
    }
}