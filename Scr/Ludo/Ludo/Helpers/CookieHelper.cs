using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using GameEngine;
using GameEngine.Helpers;

namespace Ludo.Helpers
{
    public static class CookieHelper
    {

        public static void SetArrayCookieValue(string name, string valueName, string value)
        {
            var myCookie = HttpContext.Current.Response.Cookies[name];

            if(myCookie == null)
            {
                myCookie = new HttpCookie(name);
            }

            myCookie.Values.Add(valueName, value);
            HttpContext.Current.Response.Cookies.Add(myCookie);

        }
       

        public static Game GetGameByCookie()
        {
            var id = GetGameId();
            var gid = GetGameGId();
            if(id != -1)
            {
                return GameHelper.GetGameById(id,gid);
            }

            return null;
        }

        public static int GetGameId()
        {
            var myCookie = HttpContext.Current.Request.Cookies["Game"];
            if(myCookie!= null)
            {
                if (myCookie.Values.Get("Id") != null && int.TryParse(myCookie.Values.Get("Id"), out int id))
                {
                    return id;
                }
            }
            return -1;
        }

        public static string GetGameGId()
        {
            var myCookie = HttpContext.Current.Request.Cookies["Game"];
            if (myCookie != null)
            {
                if (myCookie.Values.Get("GId") != null)
                {
                    var gid = myCookie.Values.Get("GId");
                    return gid;
                }
            }
            return null;
        }

        public static Player GetPlayer()
        {
            var myCookie = HttpContext.Current.Request.Cookies["Player"];
            if (myCookie != null)
            {
                if (myCookie.Values.Get("Id") != null && int.TryParse(myCookie.Values.Get("Id"), out int id))
                {
                    var g = HttpContext.Current.Request.Cookies["Game"];
                    if(g != null)
                    {
                        var game = GameHelper.AllGames[int.Parse(g.Values["Id"])];
                        var p = GameHelper.GetPlayerById(id, game);
                        return p;
                    }
                    
                }
            }
            return null;
        }

        public static int GetPlayerColorId()
        {
            var myCookie = HttpContext.Current.Request.Cookies["Player"];
            if (myCookie != null)
            {
                if (myCookie.Values.Get("Id") != null && int.TryParse(myCookie.Values.Get("Id"), out int id))
                {
                    return id;
                }
            }
            return -1;
        }
        // för att spara hela game-objektet till json --> cookie
        //
        //MemoryStream stream1 = new MemoryStream();
        //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(GameEngine.Game));
        //ser.WriteObject(stream1, game);

        //    stream1.Position = 0;

        //    StreamReader sr = new StreamReader(stream1);
        //Console.Write("JSON form of Game object: ");
        //    Console.WriteLine(sr.ReadToEnd());
        //    stream1.Position = 0;
        //    GameEngine.Game game2 = (GameEngine.Game)ser.ReadObject(stream1);

        public static void SetArrayCookieValue(string name, string value)
        {

            var myCookie = HttpContext.Current.Request.Cookies[name];
            
            if (myCookie == null)
            {
               myCookie = new HttpCookie(name);
            }

            myCookie.Values.Add(value, "");
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

        public static bool CheckArrayCookieValue(string name, string value)
        {
            var myCookie = HttpContext.Current.Request.Cookies[name];

            var returnValue = false;

            if (myCookie != null)
            {
                if (myCookie.Values.Keys.OfType<string>().Where(s => s == value).Count() > 0)
                {
                    return true;
                }
            }

            return returnValue;
        }

        public static void DeleteArrayCookieValue(string name, string value)
        {
            var myCookie = HttpContext.Current.Request.Cookies[name];

            if (myCookie != null)
            {
                myCookie.Values.Remove(value);
            }
        }
    }
}