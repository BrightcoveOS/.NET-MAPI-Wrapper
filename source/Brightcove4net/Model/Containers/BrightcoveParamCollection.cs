using System.Collections.Generic;
using System.Web.Script.Serialization;
using Brightcove4net.Serialization;

namespace Brightcove4net.Model.Containers
{
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
