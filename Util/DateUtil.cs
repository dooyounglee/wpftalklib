using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talkLib.Util
{
    public class DateUtil
    {
        public static string now(string format)
        {
            // format: yyyy-MM-dd HH:mm:ss.fffffff
            DateTime now = DateTime.Now;
            return now.ToString(format);
        }

        public static string TimeWhenToday(string yyyyMMddHHmmss)
        {
            var yyyyMMdd = now("yyyyMMdd");
            if (yyyyMMdd == yyyyMMddHHmmss.Substring(0, 8))
            {
                return format(yyyyMMddHHmmss, "HH:mm");
            } else
            {
                return format(yyyyMMddHHmmss, "MM-dd");
            }
        }

        public static string format(string yyyyMMddHHmmss, string format)
        {
            DateTime dt = DateTime.ParseExact(yyyyMMddHHmmss, "yyyyMMddHHmmss", null);
            return dt.ToString(format);
        }
    }
}
