using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public interface IClass
    {
        [Required(ErrorMessage = "Please Enter ID Class")]
        [Display(Name = "ID Class")]
        string IdClass { get; set; }
    }
}
