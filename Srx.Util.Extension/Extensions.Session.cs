using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Srx.Util.Extension
{
    public static class Session
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set<T>(key, value);
        }

        public static void Set(this ISession session, string key, string value)
        {
            session.Set(key, value);
        }

        public static void Set(this ISession session, string key, byte[] value)
        {
            session.Set(key, value);
        }

        public static T Get<T>(this ISession session, string key)
        {
            return session.Get<T>(key);
        }

        public static string Get(this ISession session, string key)
        {
            return session.Get(key);
        }
        
    }
}
