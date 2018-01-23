using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludo.Models;

namespace Ludo.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        [HttpGet]
        public ActionResult Index()
        {
            var name = new PlayerController();
            return View(name);
        }

        [HttpPost]
        public ActionResult Index(string product)
        {

            return View();
        }

        public ActionResult Join()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
    }
}