using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace talkLib.Util
{
    public class JsonUtil
    {
        public static string ObjectToString(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T StringToObject<T>(string s)
        {
            return JsonSerializer.Deserialize<T>(s);
        }
    }
}
