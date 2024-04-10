using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Account : IAccount
    {
        private int idAccount;
        private string user;
        private string password;
        private int role;

        public Account(int idAccount, string user, string password, int role)
        {
            this.idAccount = idAccount;
            this.user = user;
            this.password = password;
            this.role = role;
        }

        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public int IdAccount { get => idAccount; set => idAccount = value; }
    }
}