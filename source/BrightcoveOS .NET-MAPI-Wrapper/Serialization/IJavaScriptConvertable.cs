using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BrightcoveMapiWrapper.Serialization
{
	public interface IJavaScriptConvertable
	{
		IDictionary<string, object> Serialize(JavaScriptSerializer serializer);
		void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer);
	}
}
