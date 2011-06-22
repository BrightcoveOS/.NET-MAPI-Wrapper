using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Util.Extensions
{
	public static class CollectionExtensions
	{
		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
			if (collection == null || items == null)
			{
				return;
			}

			foreach (T item in items)
			{
				collection.Add(item);
			}
		}

		public static string ToQueryString(this NameValueCollection nvc)
		{
			if (nvc == null)
			{
				return "";
			}

			// The search_videos API call uses these parameters, but doesn't support multiple values 
			// being comman separated, so they must be split-out
			string[] splitOnCommas = new[] { "all", "any", "none" }; 

			StringBuilder sb = new StringBuilder();
			string amp = "";
			foreach (string key in nvc.Keys)
			{
				string[] split = splitOnCommas.Contains(key) ? nvc[key].Split(',') : new[] {nvc[key]};
				foreach (string s in split)
				{
					sb.AppendFormat("{0}{1}={2}", amp, key, HttpUtility.UrlEncode(s));
					amp = "&";
				}
			}
			return sb.ToString();
		}

		public static void AddRange(this NameValueCollection nvc, string key, IEnumerable<string> values)
		{
			if (nvc == null || values == null)
			{
				return;
			}

			foreach (string value in values)
			{
				nvc.Add(key, value);
			}
		}

		public static string ToJson(this IDictionary<string, object> dict)
		{
			JavaScriptSerializer serializer = BrightcoveSerializerFactory.GetSerializer();
			return serializer.Serialize(dict);
		}
	}
}
