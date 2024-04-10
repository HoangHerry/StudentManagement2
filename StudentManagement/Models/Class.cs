using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Class : IClass
    {
        private string idClass;

        public Class(string idClass)
        {
            this.idClass = idClass;
        }

        public string IdClass { get => idClass; set => idClass = value; }
    }
    public class Class_Student
    {
        private string idClass;
        private string idStudent;

        public Class_Student(string idClass, string idStudent)
        {
            this.idClass = idClass;
            this.idStudent = idStudent;
        }
        [Key]
        [Required(ErrorMessage = "Please Enter Name Student")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Can not use special characters in Name")]
        [MinLength(2, ErrorMessage = "Name should contain at least 2 characters")]
        public string IdClass { get => idClass; set => idClass = value; }
        public string IdStudent { get => idStudent; set => idStudent = value; }
    }
}