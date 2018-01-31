using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameEngine;
using Ludo.Models;
using Ludo.Helpers;

namespace Ludo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            var game = CookieHelper.GetGameByCookie();

            if(game != null)
            {
                
                return RedirectToRoute("Game", new { id = game.GameId });
                
            }

            return View();
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