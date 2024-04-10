using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class AccountManagement
    {
        DBConnection db;
        public AccountManagement()
        {
            db = new DBConnection();
        }
        public List<IAccount> GetAccount(int idAccount)
        {

            string sql;
            List<IAccount> accList = new List<IAccount>();
            DataTable dt = new DataTable();

            if (idAccount == 0)
            {
                sql = "select * from Account order by idAccount desc";
            }
            else
            {
                sql = "select * from Account where idAccount = @idAccount";
            }

            using (SqlConnection con = db.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                if (idAccount != 0)
                {
                    da.SelectCommand.Parameters.AddWithValue("@idAccount", idAccount);
                }

                con.Open();
                da.Fill(dt);
            }

            foreach (DataRow row in dt.Rows)
            {
                Account account = new Account(Convert.ToInt32(row["idAccount"]),
                    row["user"].ToString(),
                    row["password"].ToString(),
                    Convert.ToInt32(row["role"]));

                accList.Add(account);
            }

            return accList;
        }






        //List<IAccount> accList = new List<IAccount>()
        //{
        //    new Account(1,"admin1","Admin1@",1),
        //    new Account(2,"admin2","Admin2@",1),
        //    new Account(3,"student1","St1@",3)
        //};

        //public List<IAccount> GetAccounts(int idAccount)
        //{
        //    if (idAccount == 0)
        //    {
        //        return accList;
        //    }
        //    return accList;
        //}
    }
}