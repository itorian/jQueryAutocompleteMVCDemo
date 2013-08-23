using jQueryAutoCompleteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryAutoCompleteMVC.Controllers
{
    public class HomeController : Controller
    {

        NorthwindEntities _employees = new NorthwindEntities();

        public ActionResult QuickSearch(string term)
        {
            var result = GetEmployees(term).Select(a => new { value = a.FirstName });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private List<Employee> GetEmployees(string searchString)
        {
            return _employees.Employees
            .Where(a => a.FirstName.Contains(searchString))
            .ToList();
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
