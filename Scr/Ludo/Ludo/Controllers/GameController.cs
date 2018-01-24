using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ludo.Models;
using Ludo.Models.ViewModels;
using Ludo.Helpers;

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

        public ActionResult Game(string gameId)
        {
            var id = int.Parse(gameId);

            return View(id);
        }

        public ActionResult New()
        {
            var model = new NewGameViewModel();
            return View("New", model);
        }

        [HttpPost]
        public ActionResult New(FormCollection form)
        {
            var model = new NewGameViewModel();
            return View();
        }

        /*[HttpPost]
        public ActionResult New(FormCollection form)
        {
            // Create new GameEngine.Game() with the form-data
            // change return view to game view with Id

            return View();
        }*/

        [HttpGet]
        public ActionResult AddingPlayers(string name, string count)
        {
            ViewBag.GameName = Request.QueryString["GameName"];
            ViewBag.PlayerCount = Request.QueryString["NumberOfPlayers"];
            return View();
        }
    }
}