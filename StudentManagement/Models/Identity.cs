using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace StudentManagement.Models
{
    public class Identity
    {

        public bool IsValid(string username, string password)
        {
            AccountManagement accountManagement = new AccountManagement();
            List<IAccount> accList = accountManagement.GetAccount(0);
            foreach (IAccount acc in accList)
            {
                if (acc.User == username && acc.Password == password)
                {
                    return true;
                }
            }
            return false;

        }
        public int GetRolesForUser(string username)
        {
            AccountManagement accountManagement = new AccountManagement();
            List<IAccount> accList = accountManagement.GetAccount(0);
            int role = 0; ;
            foreach (IAccount acc in accList)
            {
                if (acc.User == username)
                {
                    role = acc.Role;
                }
            }

            return role;
        }

        //public int GetRoleForUser(string username)
        //{
        //    AccountManagement accountManagement = new AccountManagement();
        //    List<IAccount> accList = accountManagement.GetAccounts(0);

        //    int role = 0;
        //    foreach (IAccount acc in accList)
        //    {
        //        if(acc.User == username)
        //        {
        //            role = acc.Role;
        //        }
        //    }

        //    return role;
        //}
        //public bool Login(string username, string password)
        //{
        //    AccountManagement accountManagement = new AccountManagement();
        //    List<IAccount> accounts = accountManagement.GetAccounts(0);
        //    foreach (IAccount acc in accounts)
        //    {
        //        if (acc.User == username && acc.Password == password)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}