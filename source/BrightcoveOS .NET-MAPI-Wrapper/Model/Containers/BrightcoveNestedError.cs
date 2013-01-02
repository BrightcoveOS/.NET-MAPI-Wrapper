using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// A nested error returned by the Brightcove.
	/// </summary>
	public class BrightcoveNestedError : IBrightcoveError, IJavaScriptConvertable
	{
		#region IBrightcoveError implementation

		/// <summary>
		/// The error message.
		/// </summary>
		public string Message
		{
			get;
			private set;
		}

		/// <summary>
		/// The error code number.
		/// </summary>
		public int Code
		{
			get;
			private set;
		}

		/// <summary>
		/// A collection of nested errors.
		/// </summary>
		public ICollection<BrightcoveNestedError> Errors
		{
			get;
			private set;
		}

		#endregion IBrightcoveError implementation

		/// <summary>
		/// Constructor.
		/// </summary>
		public BrightcoveNestedError()
		{
			Errors = new List<BrightcoveNestedError>();
		}

		#region IJavaScriptConvertable implementation

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
						Message = dictionary[key].ToString();
						break;

					case "code":
						Code = (int)dictionary[key];
						break;

					case "errors":
						Errors.Clear();
						Errors.AddRange(serializer.ConvertToType<BrightcoveNestedError[]>(dictionary[key]));
						break;
				}
			}
		}

		#endregion
	}
}
