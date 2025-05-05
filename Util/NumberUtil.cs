using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace talkLib.Util
{
    public class NumberUtil
    {
        public static int random(int from, int to)
        {
            Random random = new Random();
            return random.Next(from, to);
        }
    }
}
