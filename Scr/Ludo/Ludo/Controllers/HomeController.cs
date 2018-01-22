using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;
using Ludo.Models;

namespace Ludo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var name = new PlayerController();
            return View(name);
        }

        public ActionResult Rules()
        {
            return View();
        }

        public ActionResult Creators()
        {
            return View();
        }
    }
}