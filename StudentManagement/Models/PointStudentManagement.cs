using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class PointStudentManagement
    {
        DBConnection db;
        public PointStudentManagement()
        {
            db = new DBConnection();
        }
        public List<PointStudent> GetStudents(string idStudent)
        {

            string sql;
            List<PointStudent> pointList = new List<PointStudent>();
            DataTable dt = new DataTable();

            if (string.IsNullOrEmpty(idStudent))
            {
                sql = "select * from PointStudent order by  idStudent desc";
            }
            else
            {
                sql = "select * from PointStudent order by  idStudent desc where idStudent = @idStudent";
            }

            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                if (!string.IsNullOrEmpty(idStudent))
                {
                    da.SelectCommand.Parameters.AddWithValue("@idStudent", idStudent);
                }


                con.Open();
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                PointStudent newPoint = new PointStudent(
                    row["idStudent"].ToString(),
                    row["idCourse"].ToString(),
                    Convert.ToDouble(row["midtermScore"]),
                    Convert.ToDouble(row["finalScore"])
                );
                pointList.Add(newPoint);
            }

            return pointList;
        }
    }
}