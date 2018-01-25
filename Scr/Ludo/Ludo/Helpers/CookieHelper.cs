using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

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
       


        public static int GetGameId()
        {
            var myCookie = HttpContext.Current.Request.Cookies["Game"];
            if(myCookie!= null)
            {
                if (myCookie.Values.Get("Id") != null)
                {
                    return int.Parse(myCookie.Values.Get("Id"));
                }
            }
            return -1;
        }



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