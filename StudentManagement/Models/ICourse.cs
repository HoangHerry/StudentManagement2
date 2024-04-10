using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface ICourse
    {
        [Required(ErrorMessage = "Please Enter ID Course")]
        [Display(Name = "ID Course")]
        string IdCourse { get ; set ; }
        [Required(ErrorMessage = "Please Enter Name Course")]
        [Display(Name = "Name Course")]
        string NameCourse { get ; set ; }
        [Required(ErrorMessage = "Please Enter Number Of Credit")]
        [Display(Name = "Number Of Credit")]
        int NumberOfCredit { get; set ; }
        [Required(ErrorMessage = "Please Enter ID Major")]
        [Display(Name = "Number Of ID Major")]
        string IdMajor { get ; set ; }
    }
}
