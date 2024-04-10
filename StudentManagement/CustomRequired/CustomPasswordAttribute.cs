using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.CustomRequired
{
    public class CustomPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string password = value.ToString();

            if (password.Length < 10 || !password.Any(c => !char.IsLetterOrDigit(c)))
            {
                return false;
            }

            if (!char.IsUpper(password[0]))
            {
                return false;
            }

            return true;
        }
    }
}