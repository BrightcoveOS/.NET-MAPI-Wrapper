using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace BrightcoveMapiWrapper.Api.Connectors
{
	public interface IRequestBuilder
	{
		/// <summary>
		/// Builds a GET request for the specified URL.
		/// </summary>
		/// <param name="url">The URL to request</param>
		/// <returns>An HttpWebRequest for GETing the specified URL.</returns>
		HttpWebRequest BuildRequest(string url);

		/// <summary>
		/// Builds a POST request for the specified URL and parameters
		/// </summary>
		/// <param name="postUrl">The URL to request</param>
		/// <param name="postParameters">The parameters to POST</param>
		/// <returns>An HttpWebRequest that will POST the specified parameters.</returns>
		HttpWebRequest BuildPostFormRequest(string postUrl, NameValueCollection postParameters);

		/// <summary>
		/// Builds a POST request for the specified URL, parameters, and file data.
		/// </summary>
		/// <param name="postUrl">The URL to request</param>
		/// <param name="postParameters">The parameters to POST</param>
		/// <param name="fileUploadInfo">Information about the file to be uploaded</param>
		/// <returns></returns>
		HttpWebRequest BuildMultipartFormDataPostRequest(string postUrl, NameValueCollection postParameters, FileUploadInfo fileUploadInfo);
	}
}
