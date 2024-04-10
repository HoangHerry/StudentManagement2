using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Person : IPerson
    {
        private string name;
        private DateTime birthday;
        private string sex;
        private string phonenumber;
        private string address;
        private string email;

        public Person(string name, DateTime birthday, string sex, string phonenumber, string address, string email)
        {
            this.name = name;
            this.birthday = birthday.Date; 
            this.sex = sex;
            this.phonenumber = phonenumber;
            this.address = address;
            this.email = email;
        }

        [Key]
        public string Name { get => name; set => name = value; }
        [Required(ErrorMessage = "Please Enter Birth of day")]

        public DateTime Birthday { get => birthday; set => birthday = value.Date; }
        [Required(ErrorMessage = "Please Enter Gender")]
        public string Sex { get => sex; set => sex = value; }
        [Required(ErrorMessage = "Please Enter Phonemumber")]
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get => address; set => address = value; }
        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get => email; set => email = value; }
        
    }
}