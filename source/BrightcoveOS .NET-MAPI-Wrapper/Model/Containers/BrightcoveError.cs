using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Model.Containers
{
	public class BrightcoveError : IJavaScriptConvertable
	{
		public string Message
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public int Code
		{
			get;
			private set;
		}

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
						Code = (int) dictionary[key];
						break;
				}
			}
		}

		#endregion
	}
}
