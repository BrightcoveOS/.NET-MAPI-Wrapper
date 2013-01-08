using System.Collections.Generic;
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

		/// <summary>
		/// Serializes the specified serializer.
		/// </summary>
		/// <param name="serializer">The serializer.</param>
		/// <returns>
		/// A serialized <see cref="IDictionary{String,Object}" />.
		/// </returns>
		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			return this;
		}

		/// <summary>
		/// Deserializes the specified dictionary.
		/// </summary>
		/// <param name="dictionary">The <see cref="IDictionary{String,Object}" />.</param>
		/// <param name="serializer">The <see cref="JavaScriptSerializer" />.</param>
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
