using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_3.Models;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        DataClasses_1DataContext dc = new DataClasses_1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectHouse()
        {
            return View(dc.Houses.ToList());
        }

        public ActionResult ViewHouse()
        {
            string Area = Request["Area"];
            var query = dc.Houses.Where(h => h.Area == Area);
            return View(query);
        }

        public ActionResult AddHouse()
        {
            return View();
        }

        public ActionResult AddHouse_2()
        {
            Houses h = new Houses();
            h.Area = Request["Area"];
            h.Address = Request["Address"];
            h.Marlas = Request["Marlas"];
            h.Price = Request["Price"];

            dc.Houses.InsertOnSubmit(h);
            dc.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditHouse(int Id)
        {
            return View(dc.Houses.First(h => h.Id == Id));
        }

        public ActionResult EditHouse_2(int Id)
        {
            var q = dc.Houses.First(h => h.Id == Id);
            q.Area = Request["Area"];
            q.Address = Request["Address"];
            q.Marlas = Request["Marlas"];
            q.Price = Request["Price"];

            dc.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}