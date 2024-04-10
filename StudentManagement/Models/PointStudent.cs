using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class PointStudent 
    {
        private string idStudent;
        private string idCourse;
        private double midterm_Score;
        private double final_Score;
        private double avg_score;

        

        public PointStudent(string idStudent, string idCourse, double midterm_Score, double final_Score)
        {
            this.idStudent = idStudent;
            this.idCourse = idCourse;
            this.midterm_Score = midterm_Score;
            this.final_Score = final_Score;
            this.avg_score = Math.Round((midterm_Score + final_Score) / 2, 1);
        }

        [Required(ErrorMessage = "Please Enter ID Student")]
        [Display(Name = "ID Student")]
        public string IdStudent { get => idStudent; set => idStudent = value; }
        [Required(ErrorMessage = "Please Enter ID Course")]
        [Display(Name = "ID Course")]
        public string IdCourse { get => idCourse; set => idCourse = value; }
        [Required(ErrorMessage = "Please Enter Midterm Score")]
        [Display(Name = "Midterm Score")]
        public double Midterm_Score { get => midterm_Score; set => midterm_Score = value; }
        [Required(ErrorMessage = "Please Enter Final Score")]
        [Display(Name = "Final Score")]
        public double Final_Score { get => final_Score; set => final_Score = value; }
        public double Avg_score { get => avg_score; }
    }
}