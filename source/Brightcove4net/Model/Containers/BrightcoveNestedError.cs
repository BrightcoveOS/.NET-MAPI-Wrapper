using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Brightcove4net.Serialization;
using Brightcove4net.Util.Extensions;

namespace Brightcove4net.Model.Containers
{
	public class BrightcoveNestedError : IJavaScriptConvertable
	{
		public string Message
		{
			get;
			private set;
		}

		public int Code
		{
			get;
			private set;
		}

		public ICollection<BrightcoveNestedError> Errors
		{
			get;
			private set;
		}

		public BrightcoveNestedError()
		{
			Errors = new List<BrightcoveNestedError>();
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
