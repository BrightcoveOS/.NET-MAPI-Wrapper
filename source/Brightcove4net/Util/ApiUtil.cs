using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using Brightcove4net.Api;
using Brightcove4net.Model;
using Brightcove4net.Model.Containers;

namespace Brightcove4net.Util
{
	public static class ApiUtil
	{
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

		private static void ThrowIfNestedError(object objError, JavaScriptSerializer serializer)
		{
			if (objError != null)
			{
				BrightcoveError error = serializer.ConvertToType<BrightcoveError>(objError);
				throw new BrightcoveApiException(error);
			}
		}

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
