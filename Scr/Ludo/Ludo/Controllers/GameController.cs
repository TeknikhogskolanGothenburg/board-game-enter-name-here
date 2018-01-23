using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludo.Models;
<<<<<<< HEAD
=======
using Ludo.Models.ViewModels;
using Ludo.Helpers;
>>>>>>> d7c692adc2f823ebb1d0cd6722dfd0156789d65a

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

        public ActionResult Game(string gameId)
        {
            var id = int.Parse(gameId);

            return View("Game");
        }

        [HttpGet]
        public ActionResult Join()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Join(FormCollection form)
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var model = new NewGameViewModel();
            return View("New", model);
        }

        [HttpPost]
        public ActionResult New(FormCollection form)
        {
            // Create new GameEngine.Game() with the form-data
            // change return view to game view with Id

            return View("Index");
        }
    }
}