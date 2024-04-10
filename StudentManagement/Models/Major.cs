using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Major
    {
        private string idMajor;
        private string nameMajor;

        public Major(string idMajor, string nameMajor)
        {
            this.idMajor = idMajor;
            this.nameMajor = nameMajor;
        }

        public string IdMajor { get => idMajor; set => idMajor = value; }
        public string NameMajor { get => nameMajor; set => nameMajor = value; }
    }
}