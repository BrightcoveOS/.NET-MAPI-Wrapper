using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// A collection of custom field values.
	/// </summary>
	public class CustomFieldCollection : Dictionary<string, string>, IJavaScriptConvertable
	{
		#region IJavaScriptConvertable implementation

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			return this.ToDictionary(d => d.Key, d => (object)d.Value);
		}

		public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
		{
			foreach (KeyValuePair<string, object> keyValuePair in dictionary)
			{
				Add(keyValuePair.Key, keyValuePair.Value as string);
			}
		}

		#endregion
	}
}
