using System.Collections.Specialized;

namespace Brightcove4net.Api.Connectors
{
	public interface IBrightcoveApiConnector
	{
		IRequestBuilder RequestBuilder { get; set; }
		BrightcoveApiConfig Configuration { get; set; }
		string GetResponseJson(NameValueCollection requestParams);
		string GetPostResponseJson(string postJson);
		string GetFilePostResponseJson(string postJson, string fileName, byte[] fileData);
	}
}
