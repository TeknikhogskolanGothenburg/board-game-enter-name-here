using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;

namespace Ludo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rules()
        {
            ViewBag.Result1 = "This is the result";
            return View();
        }

        public ActionResult Creators()
        {
            return View();
        }
    }
}