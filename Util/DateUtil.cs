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
            // format: yyyy-MM-dd HH:mm:dd.fffffff
            DateTime now = DateTime.Now;
            return now.ToString(format);
        }
    }
}
