using DisposalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisposalManagement.Controllers
{
    public class HomeController : Controller
    {
        private DisposalManagementContext db = new DisposalManagementContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Managers()
        {
            return View(db.Managers);
        }
    }
}
