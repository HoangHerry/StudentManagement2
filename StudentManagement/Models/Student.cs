using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Student : Person, IStudent
    {
        private string idStudent;
        private string idMajor;
        private int idAccount;

        public Student(string idStudent, string idMajor, string name, DateTime birthday, string sex, string phonenumber, string address, string email, int idAccount) : base(name, birthday, sex, phonenumber, address, email)
        {
            this.idStudent = idStudent;
            this.idMajor = idMajor;
            this.idAccount = idAccount;
        }
        [Key]
        
        public string IdStudent { get => idStudent; set => idStudent = value; }
        [Required(ErrorMessage = "Please Enter ID Major")]
        [Display(Name = "ID Major")]
        public string IdMajor { get => idMajor; set => idMajor = value; }
        [Required(ErrorMessage = "Please Enter ID Account")]
        [Display(Name = "ID Account")]
        public int IdAccount { get => idAccount; set => idAccount = value; }



        

    }
}