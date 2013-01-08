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

		/// <summary>
		/// Serializes the specified serializer.
		/// </summary>
		/// <param name="serializer">The serializer.</param>
		/// <returns>
		/// A serialized <see cref="IDictionary{String,Object}" />.
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Deserializes the specified dictionary.
		/// </summary>
		/// <param name="dictionary">The <see cref="IDictionary{String,Object}" />.</param>
		/// <param name="serializer">The <see cref="JavaScriptSerializer" />.</param>
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
