using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IStudent : IPerson
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Name Student")]
        [RegularExpression(@"^[A-Za-z 0-9]*$", ErrorMessage = "Can not use special characters in Name")]
        [MinLength(2,ErrorMessage ="Name should contain at least 2 characters")]
        string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Birth of day")]
        [Display(Name = "Birth of day")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]
        [Display(Name = "Gender")]
        string Sex { get; set; }
        [Required(ErrorMessage = "Please Enter Phonemumber")]
        [Display(Name = "Phonenumber")]
        string Phonenumber { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        [Display(Name = "Address")]
        string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Email")]
        string Email { get; set; }
        [Required(ErrorMessage = "Please Enter ID Student")]
        string IdStudent { get; set; }
        [Required(ErrorMessage = "Please Enter ID Major")]
        [Display(Name = "ID Major")]
        string IdMajor { get ; set ; }
        [Required(ErrorMessage = "Please Enter ID Account")]
        [Display(Name = "ID Account")]
        int IdAccount { get; set; }
    }
}
