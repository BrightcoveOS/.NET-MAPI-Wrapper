using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BrightcoveMapiWrapper.Serialization
{
	/// <summary>
	/// Defines the way Brightcove objects are converted to and from JSON.
	/// </summary>
	public interface IJavaScriptConvertable
	{
		/// <summary>
		/// Serializes the specified serializer.
		/// </summary>
		/// <param name="serializer">The serializer.</param>
		/// <returns>A serialized <see cref="IDictionary{String,Object}"/>.</returns>
		IDictionary<string, object> Serialize(JavaScriptSerializer serializer);
		
		/// <summary>
		/// Deserializes the specified dictionary.
		/// </summary>
		/// <param name="dictionary">The <see cref="IDictionary{String,Object}"/>.</param>
		/// <param name="serializer">The <see cref="JavaScriptSerializer"/>.</param>
		void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer);
	}
}
