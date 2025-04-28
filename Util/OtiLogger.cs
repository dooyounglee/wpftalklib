using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OTILib.Util
{
    public static class OtiLogger
    {
        public static void log1(object str, [CallerFilePath] string filepath = ""
                                          , [CallerMemberName] string membername = ""
                                          , [CallerLineNumber] int linenumber = 0)
        {
            string header = string.Format("{0} {1}:{2} ", filepath, membername, linenumber);
            Debug.WriteLine(header + str);
        }

        //public delegate void WriteDelegate(string str, params Object[] args);
        //public delegate void WriteDelegate1(string str);
        //public static WriteDelegate1 log1([CallerFilePath] string filepath = ""
        //                                  , [CallerMemberName] string membername = ""
        //                                  , [CallerLineNumber] int linenumber = 0)
        //{
        //    Debug.WriteLine("eeeeeeeeee");
        //    return new WriteDelegate1(str =>
        //    {
        //        Debug.WriteLine("ddddddddddddddd");
        //        string header = string.Format("{0}:{2} {1}(...) ", filepath, membername, linenumber);
        //        Debug.WriteLine(header + string.Format(str));
        //    });
        //}
        //
        //public static WriteDelegate log2([CallerFilePath] string filepath = ""
        //                                  , [CallerMemberName] string membername = ""
        //                                  , [CallerLineNumber] int linenumber = 0)
        //{
        //    Debug.WriteLine("eeeeeeeeee");
        //    return new WriteDelegate((str, args) =>
        //    {
        //        Debug.WriteLine("ddddddddddddddd");
        //        string header = string.Format("{0}:{2} {1}(...) ", filepath, membername, linenumber);
        //        Debug.WriteLine(header + string.Format(str, args));
        //    });
        //}
    }
}
