using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class CourseInformationManagement
    {
        DBConnection db;
        public CourseInformationManagement()
        {
            db = new DBConnection();
        }
        public List<ICourse> GetCourses(string idCourse, string idMajor)
        {

            string sql;
            List<ICourse> courseList = new List<ICourse>();
            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(idCourse) && string.IsNullOrEmpty(idMajor))
            {
                sql = "select * from Course order by idCourse DESC";
            }
            else if (!string.IsNullOrEmpty(idCourse) && string.IsNullOrEmpty(idMajor))
            {
                sql = "select * from Course where idCourse = @idCourse";
            }
            else
            {
                sql = "select * from Course where idMajor = @idMajor";
            }

            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                if (!string.IsNullOrEmpty(idCourse))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idCourse", idCourse);
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
                Course course = new Course(
                    row["idCourse"].ToString(), row["nameCourse"].ToString(), Convert.ToInt32(row["numberOfCredit"]), row["idMajor"].ToString()
                    );

                courseList.Add(course);
            }

            return courseList;
        }
        public List<ClassBeLongsToCourse> GetClassBeLongsToCourses(string idCourse)
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
        public void AddClassToCourse(ClassBeLongsToCourse newclassBeLongsToCourse)
        {
            using (SqlConnection con = db.GetConnection())
            {
                string sql = "INSERT INTO Course_Class (idCourse, idClass) VALUES (@idCourse , @idClass)";

                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idCourse", newclassBeLongsToCourse.IdCourse);
                cmd.Parameters.AddWithValue("@idClass", newclassBeLongsToCourse.IdClass);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }





        //List<ICourse> courseList = new List<ICourse>()
        //{
        //    new Course("Sec","Security",10,"IT"),
        //    new Course("Db","Database",11,"IT"),
        //    new Course("Net","Networking",10,"IT"),
        //    new Course("Pro","Programming",10,"IT"),

        //};

        //public List<ICourse> getCourseList(string idCourse, string idMajor, int role)
        //{
        //    if(role ==1)
        //    {
        //        List<ICourse> filteredCourses = new List<ICourse>();

        //        if (!string.IsNullOrEmpty(idCourse) && string.IsNullOrEmpty(idMajor))
        //        {
        //            foreach (ICourse course in courseList)
        //            {
        //                if (course.IdCourse == idCourse)
        //                {
        //                    filteredCourses.Add(course);
        //                    return filteredCourses;
        //                }
        //            }
        //        }

        //        return courseList;
        //    }
        //    return null;
        //}
        //public List<ICourse> addCourse(ICourse course,int role)
        //{
        //    courseList.Add(course);
        //    return getCourseList(string.Empty, string.Empty, role);

        //}
    }
}