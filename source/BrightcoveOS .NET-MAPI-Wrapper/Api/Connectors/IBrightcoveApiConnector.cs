using System.Collections.Specialized;

namespace BrightcoveMapiWrapper.Api.Connectors
{
	/// <summary>
	/// Defines the way to connect to Brightcove's API. 
	/// </summary>
	public interface IBrightcoveApiConnector
	{
		/// <summary>
		/// Defines a <see cref="IRequestBuilder"/>.
		/// </summary>
		IRequestBuilder RequestBuilder { get; set; }
		/// <summary>
		/// Defines a <see cref="BrightcoveApiConfig"/>
		/// </summary>
		BrightcoveApiConfig Configuration { get; set; }
		/// <summary>
		/// Defines a method used to retrieve the json string returned from an HTTP GET request to Brightcove's REST API.
		/// </summary>
		/// <param name="requestParams">A name value collection of parameters.</param>
		/// <returns></returns>
		string GetResponseJson(NameValueCollection requestParams);
		/// <summary>
		/// Defines a method used to retrieve the json string returned from an HTTP POST request to Brightcove's REST API.
		/// </summary>
		/// <param name="postJson"></param>
		/// <returns></returns>
		string GetPostResponseJson(string postJson);
		/// <summary>
		/// Defines a method used to retrieve the json string returned from an HTTP GET request to Brightcove's REST API. Includes file data.
		/// </summary>
		/// <param name="postJson"></param>
		/// <param name="fileUploadInfo"></param>
		/// <returns></returns>
		string GetFilePostResponseJson(string postJson, FileUploadInfo fileUploadInfo);
	}
}
