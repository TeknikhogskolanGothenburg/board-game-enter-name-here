using System;
using System.Web;
using GameEngine;

namespace Ludo.Models
{
    public class PlayerController
    {
        public string CurrentPlayer()
        {
            var currentPlayerName = new Player();
            return currentPlayerName.Name;
        }
    }
}
