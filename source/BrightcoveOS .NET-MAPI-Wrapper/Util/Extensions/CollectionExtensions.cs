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
	/// <summary>
	/// A set of extension methods for various types of collections used through the wrapper.
	/// </summary>
	public static class CollectionExtensions
	{
		/// <summary>
		/// Adds the elements of the specified <see cref="IEnumerable{T}"/> to the <see cref="ICollection{T}"/>.
		/// </summary>
		/// <typeparam name="T">The type of element to add.</typeparam>
		/// <param name="collection">The initial collection.</param>
		/// <param name="items">The items to add.</param>
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

		/// <summary>
		/// Converts a <see cref="NameValueCollection"/> to query string parameters.
		/// </summary>
		/// <param name="nvc">The initial <see cref="NameValueCollection"/>.</param>
		/// <returns>A properly formatted query string.</returns>
		public static string ToQueryString(this NameValueCollection nvc)
		{
			if (nvc == null)
			{
				return "";
			}

			// The search_videos API call uses these parameters, but doesn't support multiple values 
			// being comma separated, so they must be split-out.
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

		/// <summary>
		/// Adds the elements of the specified <see cref="IEnumerable{T}"/> for the given <paramref name="key"/> to the <see cref="NameValueCollection"/>.
		/// </summary>
		/// <param name="nvc">The given <see cref="NameValueCollection"/>.</param>
		/// <param name="key">The key for which to add additional values.</param>
		/// <param name="values">The values to add to the given key.</param>
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

		/// <summary>
		/// Converts an <see cref="IDictionary{String, Object}"/> to a JSON string.
		/// </summary>
		/// <param name="dict">The <see cref="IDictionary{String, Object}"/> to convert.</param>
		/// <returns>A JSON string.</returns>
		public static string ToJson(this IDictionary<string, object> dict)
		{
			JavaScriptSerializer serializer = BrightcoveSerializerFactory.GetSerializer();
			return serializer.Serialize(dict);
		}
	}
}
