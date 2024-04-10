using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace StudentManagement.Models
{
    public class StudentInformationManagement
    {

        DBConnection db;
        public StudentInformationManagement()
        {
            db = new DBConnection();
        }

        public List<IStudent> GetStudents(string IdStudent, string idMajor)
        {

            string sql;
            List<IStudent> stuList = new List<IStudent>();
            DataTable dt = new DataTable();

            //Processes retrieving student information by Student ID or Major ID when it is passed in
            if (string.IsNullOrEmpty(IdStudent) && string.IsNullOrEmpty(idMajor))
            {
                sql = "select * from Student order by idStudent desc";
            }
            else if (!string.IsNullOrEmpty(IdStudent) && string.IsNullOrEmpty(idMajor))
            {
                sql = "select * from Student where idStudent = @IdStudent";
            }
            else
            {
                sql = "select * from Student where idMajor = @idMajor";
            }

            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                if (!string.IsNullOrEmpty(IdStudent))
                {
                    da.SelectCommand.Parameters.AddWithValue("@IdStudent", IdStudent);
                }
                if (!string.IsNullOrEmpty(idMajor))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idMajor", idMajor);
                }

                con.Open();
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
               Student student = new Student(
                   row["idStudent"].ToString(),
                   row["idMajor"].ToString(),
                   row["name"].ToString(),
                   Convert.ToDateTime(row["birthday"]),
                   Convert.ToInt32(row["gender"]) == 1 ? "Male" : Convert.ToInt32(row["gender"]) == 2 ? "Female" : "Undefined",
                   row["phonenumber"].ToString(),
                   row["address"].ToString(),
                   row["email"].ToString(),
                   row["idAccount"] != DBNull.Value ? Convert.ToInt32(row["idAccount"]) : 0
               );
                stuList.Add(student);
            }

            return stuList;
        }




        public void AddStudent(Student newStudent)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string sql = "INSERT INTO Student (IdStudent, IdMajor, Name, Birthday, Gender, Phonenumber, Address, Email, IdAccount) VALUES (@IdStudent, @IdMajor, @Name, @Birthday, @Gender, @Phonenumber, @Address, @Email ,@IdAccount)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAccount", newStudent.IdAccount == 0 ? DBNull.Value : (object)newStudent.IdAccount);
                cmd.Parameters.AddWithValue("@IdMajor", newStudent.IdMajor);
                cmd.Parameters.AddWithValue("@Name", newStudent.Name);
                cmd.Parameters.AddWithValue("@Birthday", newStudent.Birthday);
                string gender = newStudent.Sex.ToLower();
                int genderValue = gender == "male" ? 1 : gender == "female" ? 2 : 3;
                cmd.Parameters.AddWithValue("@Gender", genderValue);
                cmd.Parameters.AddWithValue("@Phonenumber", newStudent.Phonenumber);
                cmd.Parameters.AddWithValue("@Address", newStudent.Address);
                cmd.Parameters.AddWithValue("@Email", newStudent.Email);
                cmd.Parameters.AddWithValue("@IdStudent", newStudent.IdStudent);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string sql = "UPDATE Student SET IdMajor = @IdMajor, Name = @Name, Birthday = @Birthday, Gender = @Gender, Phonenumber = @Phonenumber, Address = @Address, Email = @Email, IdAccount = @IdAccount WHERE IdStudent = @IdStudent";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdAccount", student.IdAccount == 0 ? DBNull.Value : (object)student.IdAccount);
                cmd.Parameters.AddWithValue("@IdMajor", student.IdMajor);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Birthday", student.Birthday);
                string gender = student.Sex.ToLower();
                int genderValue = gender == "male" ? 1 : gender == "female" ? 2 : 3;
                cmd.Parameters.AddWithValue("@Gender", genderValue);
                cmd.Parameters.AddWithValue("@Phonenumber", student.Phonenumber);
                cmd.Parameters.AddWithValue("@Address", student.Address);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@IdStudent", student.IdStudent);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void DeleteStudent(Student student)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string sql = "DELETE Student WHERE IdStudent = @IdStudent";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdStudent", student.IdStudent);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }











        //        List<IStudent> stuList = new List<IStudent>()
        //{
        //    new Student("BD00436", "IT", "Le Viet Hoang", new DateTime(2004, 11, 16), "male", "0814254442", "Quang Binh", "hoang19876mail.com", 0),
        //    new Student("BD00234", "IT", "Le Viet Hoang", new DateTime(2004, 11, 16), "male", "0814254442", "Quang Binh", "hoang19876mail.com", 0),
        //    new Student("BD00556", "IT", "Le Viet Hoang", new DateTime(2004, 11, 16), "male", "0814254442", "Quang Binh", "hoang19876mail.com", 0),
        //    new Student("BD00789", "IT", "Le Viet Hoang", new DateTime(2004, 11, 16), "male", "0814254442", "Quang Binh", "hoang19876mail.com", 0)
        //};

        //        public List<IStudent> GetStudents(string idStudent, string idMajor)
        //        {
        //            List<IStudent> filteredStudents = new List<IStudent>();

        //            if (!string.IsNullOrEmpty(idStudent) && string.IsNullOrEmpty(idMajor))
        //            {
        //                foreach (IStudent student in stuList)
        //                {
        //                    if (student.IdStudent == idStudent)
        //                    {
        //                        filteredStudents.Add(student);
        //                        return filteredStudents;
        //                    }
        //                }
        //            }

        //            return stuList;

        //        }
        //        public List<IStudent> AddStudent(IStudent student)
        //        {
        //            if (!string.IsNullOrEmpty(student.IdStudent) &&
        //                !string.IsNullOrEmpty(student.IdMajor) &&
        //                !string.IsNullOrEmpty(student.Name) &&
        //                student.Birthday != DateTime.MinValue &&
        //                !string.IsNullOrEmpty(student.Sex) &&
        //                !string.IsNullOrEmpty(student.Phonenumber) &&
        //                !string.IsNullOrEmpty(student.Address) &&
        //                !string.IsNullOrEmpty(student.Email) &&
        //                student.IdAccount >= 0)
        //            {
        //                stuList.Add(student);
        //                return GetStudents(string.Empty,string.Empty);
        //            }
        //            return GetStudents(string.Empty, string.Empty);
        //        }

        //        public List<IStudent> DeleteStudent(string idStudent)
        //        {
        //            if (IsIDStudent(idStudent) == true && !string.IsNullOrEmpty(idStudent))
        //            {
        //                foreach (IStudent student in stuList)
        //                {
        //                    if (student.IdStudent == idStudent)
        //                    {
        //                        stuList.Remove(student);
        //                        return GetStudents(string.Empty, string.Empty);
        //                    }
        //                }
        //            }
        //            return GetStudents(string.Empty, string.Empty);
        //        }
        //        public bool IsIDStudent(string idStudent)
        //        {
        //            string pattern = @"^BD\d+$";
        //            Regex regex = new Regex(pattern);

        //            return regex.IsMatch(idStudent);
        //        }
        //        public List<IStudent> UpdateStudent(Student student)
        //        {
        //            if (!string.IsNullOrEmpty(student.IdStudent) &&
        //                !string.IsNullOrEmpty(student.IdMajor) &&
        //                !string.IsNullOrEmpty(student.Name) &&
        //                student.Birthday != DateTime.MinValue &&
        //                !string.IsNullOrEmpty(student.Sex) &&
        //                !string.IsNullOrEmpty(student.Phonenumber) &&
        //                !string.IsNullOrEmpty(student.Address) &&
        //                !string.IsNullOrEmpty(student.Email) &&
        //                student.IdAccount >= 0)
        //            {
        //                foreach (IStudent stu in stuList)
        //                {
        //                    if (stu.IdStudent == student.IdStudent)
        //                    {
        //                        int index = stuList.IndexOf(stu);
        //                        stuList[index] = student;
        //                        return GetStudents(string.Empty, string.Empty);
        //                    }
        //                }
        //            }
        //            return GetStudents(string.Empty, string.Empty);
        //        }
    }
}