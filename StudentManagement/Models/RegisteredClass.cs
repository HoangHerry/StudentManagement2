using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class RegisteredClass
    {
        DBConnection db;
        public RegisteredClass()
        {
            db = new DBConnection();
        }
        public List<Class_Student> GetStudentBelongClass(string idClass)
        {
            string sql;
            List<Class_Student> Class_Student_list = new List<Class_Student>();
            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(idClass))
            {
                sql = "select * from Class_Student";
            }
            else
            {
                sql = "select * from Class_Student where idClass = @idClass";
            }

            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                if (!string.IsNullOrEmpty(idClass))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idClass", idClass);
                }

                con.Open();
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                Class_Student class_student = new Class_Student(
                    row["idClass"].ToString(), row["idStudent"].ToString()
                    );
                Class_Student_list.Add(class_student);
            }

            return Class_Student_list;
        }
        public List<ClassBeLongsToCourse> getClassesByIdCourse(string idCourse)
        {
            string sql;
            List<ClassBeLongsToCourse> Couse_Class_List = new List<ClassBeLongsToCourse>();
            DataTable dt = new DataTable();
            sql = "select * from Course_Class where idCourse = @idCourse";

            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                if (!string.IsNullOrEmpty(idCourse))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idCourse", idCourse);
                }

                con.Open();
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                ClassBeLongsToCourse couse_class = new ClassBeLongsToCourse(
                    row["idCourse"].ToString(), row["idClass"].ToString()
                    );
                Couse_Class_List.Add(couse_class);
            }

            return Couse_Class_List;
        }
        public void addClassforStudent(Class_Student class_student)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string sql = "INSERT INTO Class_Student (idClass, idStudent) VALUES (@idClass, @idStudent)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idClass", class_student.IdClass);
                cmd.Parameters.AddWithValue("@idStudent", class_student.IdStudent);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}