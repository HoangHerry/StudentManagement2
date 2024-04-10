using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace StudentManagement.Models
{
    public interface IPerson
    {
        [Key]
        string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Birth of day")]
        DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Please Enter Gender")]
        string Sex { get; set; }
        [Required(ErrorMessage = "Please Enter Phonemumber")]
        string Phonenumber { get; set; }
        [Required(ErrorMessage = "Please Enter Address")]
        string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        string Email { get; set; }
    }
}
