﻿using System.Text;

namespace OTILib.Util
{
    public class ConvertUtil
    {
        public static string ConvertDictionaryToString<DKey, DValue> (Dictionary<DKey, DValue> dict)
        {
	        string format = "{0}='{1}',";

            StringBuilder itemString = new StringBuilder();
	        foreach(KeyValuePair<DKey, DValue> kv in dict)
	        {
		        itemString.AppendFormat(format, kv.Key, kv.Value);
	        }
            itemString.Remove(itemString.Length - 1, 1);

	        return itemString.ToString();
        }

        public static Dictionary < string, string> ConvertStringToDictionary(string dictString)
        {
            // string format must be like
            // "key='value",key='value',key='value' ..."
            return dictString.Split(',')
                             .Select(pp => pp.Trim().Split('='))
					         .ToDictionary(pp => pp[0], pp => pp[1]);
        }
    }
}
