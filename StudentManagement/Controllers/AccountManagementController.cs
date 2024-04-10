using PagedList;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class AccountManagementController : Controller
    {
        public ActionResult Index(int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 6;
            }
            AccountManagement accountManagement = new AccountManagement();
            List<IAccount> obj = accountManagement.GetAccount(0);
            return View(obj.ToPagedList((int)page, (int)pageSize));
        }
    }
}