using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPerpustakaan.Helpers
{
    public class SessionManager
    {
        public static void Set<T>(string key, T entity)
        {
            HttpContext.Current.Session[key] = entity;
        }
        public static T Get<T>(string key)
        {
            object sessionObject = HttpContext.Current.Session[key];
            if (sessionObject == null)
            {
                return default(T);
            }
            return (T)HttpContext.Current.Session[key];
        }
        public static void Remove(string key)
        {
            HttpContext.Current.Session.Remove(key);
        }
    }
}