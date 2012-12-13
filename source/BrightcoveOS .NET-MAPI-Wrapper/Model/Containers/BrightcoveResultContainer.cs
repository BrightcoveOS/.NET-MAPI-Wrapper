using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// A container for items contained within the POST response container.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BrightcoveResultContainer<T> : IJavaScriptConvertable
	{
		/// <summary>
		/// A type of result.
		/// </summary>
		public T Result
		{
			get;
			private set;
		}

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			throw new NotImplementedException();
		}

		public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
		{
			foreach (string key in dictionary.Keys)
			{
				switch (key)
				{
					case "error":
						ApiUtil.ThrowIfError(dictionary, key, serializer);
						break;

					case "result":
						Result = serializer.ConvertToType<T>(dictionary[key]);
						break;
				}
			}
		}
	}
}
