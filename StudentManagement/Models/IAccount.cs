using Microsoft.AspNet.Identity;
using StudentManagement.CustomRequired;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IAccount
    {
        [Key]
        int IdAccount { get ; set; }
        [Required(ErrorMessage = "Please Enter User")]
        [Display(Name = "User")]
        string User { get ; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        [CustomPassword(ErrorMessage = "Password must start with an uppercase letter, be at least 10 characters long, and contain at least one special character")]
        string Password { get ; set ; }
        [Required(ErrorMessage = "Please Enter Role")]
        [Display(Name = "Role")]
        int Role { get; set; }
    }
}
