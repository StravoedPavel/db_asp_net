using EmployeeDBApplication.DataAccess;
using EmployeeDBApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDBApplication.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeApplicationDB db = new EmployeeApplicationDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            db.Database.ExecuteSqlCommand("EXEC GodInsertProcedure");
            return View("Created");
        }

        public ActionResult Delete()
        {
            db.Database.ExecuteSqlCommand("EXEC GodDeleteProcedure");
            return View("Deleted");
        }

        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}