using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// An error returned from the Brightcove API.
	/// </summary>
	public class BrightcoveError : IBrightcoveError, IJavaScriptConvertable
	{
		#region Properties

		/// <summary>
		/// The name of the error.
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		#endregion Properties

		#region IBrightcoveError implementation

		/// <summary>
		/// The error code message.
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

		#endregion IBrightcoveError implementation

		#region IJavaScriptConvertable implementation

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
					case "name":
						Name = dictionary[key].ToString();
						break;

					case "message":
						Message = dictionary[key].ToString();
						break;

					case "code":
						Code = (int)dictionary[key];
						break;
				}
			}
		}

		#endregion
	}
}
