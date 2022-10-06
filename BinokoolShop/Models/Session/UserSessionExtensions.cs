using BinokoolShop.Models.Entity;
using System.Text.Json;

namespace BinokoolShop.Models.Session
{
    public static class UserSessionExtensions
    {
        public static void Set<T>(ISession session, List<Cart> value, string key)
        {
            string f = JsonSerializer.Serialize(value);
            session.SetString(key, JsonSerializer.Serialize(value));
            
        }

        public static T? Get<T>(ISession session, string key)
        {
            var value = session.GetString(key);
            if(value == null)
            {
                return default;
            }
            else
            {
                return JsonSerializer.Deserialize<T>(value);
            }
        }
    }
}
