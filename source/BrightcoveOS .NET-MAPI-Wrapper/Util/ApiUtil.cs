using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Containers;

namespace BrightcoveMapiWrapper.Util
{
	/// <summary>
	/// Checks for errors and throws exceptions where applicable.
	/// </summary>
	public static class ApiUtil
	{
		/// <summary>
		/// Throws an exception if certain conditions are met.
		/// </summary>
		/// <param name="dictionary"></param>
		/// <param name="key"></param>
		/// <param name="serializer"></param>
		public static void ThrowIfError(IDictionary<string, object> dictionary, string key, JavaScriptSerializer serializer)
		{
			// Errors are returned in two different formats. For now, we can tell the difference 
			// by checking to see whether dictionary[key] is a string, or another nested dictionary. 
			// A little hacky, perhaps, but gets the job done.

			string test = dictionary[key] as string;
			if (test != null)
			{
				ThrowIfError(dictionary, serializer);
			}
			else 
			{
				ThrowIfNestedError(dictionary[key], serializer);
			}
		}

		/// <summary>
		/// Throws an exception if certain conditions are met.
		/// </summary>
		/// <param name="objError"></param>
		/// <param name="serializer"></param>
		private static void ThrowIfNestedError(object objError, JavaScriptSerializer serializer)
		{
			if (objError != null)
			{
				BrightcoveError error = serializer.ConvertToType<BrightcoveError>(objError);
				throw new BrightcoveApiException(error);
			}
		}

		/// <summary>
		/// Throws an exception if certain conditions are met.
		/// </summary>
		/// <param name="objError"></param>
		/// <param name="serializer"></param>
		private static void ThrowIfError(object objError, JavaScriptSerializer serializer)
		{
			if (objError != null)
			{
				BrightcoveNestedError error = serializer.ConvertToType<BrightcoveNestedError>(objError);
				throw new BrightcoveApiException(error);
			}
		}
	}
}
