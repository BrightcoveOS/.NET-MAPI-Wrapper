﻿using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// A dictionary of Brightcove parameters.
	/// </summary>
	public class BrightcoveParamCollection : Dictionary<string, object>, IJavaScriptConvertable
	{
		#region IJavaScriptConvertable implementation

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			return this;
		}

		public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
		{
			foreach (KeyValuePair<string, object> keyValuePair in dictionary)
			{
				Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		#endregion
	}
}
