using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using Brightcove4net.Util;
using Brightcove4net.Util.Extensions;

namespace Brightcove4net.Api.Connectors
{
	public class BrightcoveApiConnector : IBrightcoveApiConnector
	{
		public IRequestBuilder RequestBuilder
		{
			get; 
			set;
		}

		public BrightcoveApiConfig Configuration
		{
			get;
			set;
		}

		public BrightcoveApiConnector(BrightcoveApiConfig configuration) : 
			this(configuration, new BasicRequestBuilder(configuration))
		{	
		}

		public BrightcoveApiConnector(BrightcoveApiConfig configuration, IRequestBuilder requestBuilder)
		{
			Configuration = configuration;
			RequestBuilder = requestBuilder;
		}

		/// <summary>
		/// Performs an API Read (HTTP GET) request based on the specified params.
		/// </summary>
		/// <param name="requestParams"></param>
		/// <returns></returns>
		public virtual string GetResponseJson(NameValueCollection requestParams)
		{
			// Build the URL
			string url = String.Format("{0}?{1}", Configuration.ApiReadUrl, requestParams.ToQueryString());

			// Log the request URL
			Debug.WriteLine(String.Format("Request URL: {0}", url));

			// Make the request
			HttpWebRequest request = RequestBuilder.BuildRequest(url);
			string json = PerformRequest(request);

			Debug.WriteLine(String.Format("JSON Response: \n{0}", json));

			return json;
		}

		/// <summary>
		/// Performs an API Write (HTTP POST) request 
		/// </summary>
		/// <param name="postJson"></param>
		/// <returns></returns>
		public virtual string GetPostResponseJson(string postJson)
		{
			return GetPostResponseJson(postJson, null);
		}

		/// <summary>
		/// Performs an API Write (HTTP POST) request that includes file data
		/// </summary>
		/// <param name="postJson"></param>
		/// <param name="fileName"></param>
		/// <param name="fileData"></param>
		/// <returns></returns>
		public virtual string GetFilePostResponseJson(string postJson, string fileName, byte[] fileData)
		{
			return GetPostResponseJson(postJson, d => d.Add("file", new FormUploadUtil.FileParameter(fileData, fileName)));
		}

		/// <summary>
		/// Performs an API Write (HTTP POST) request, with an optional callback to add extra request params
		/// </summary>
		/// <param name="postJson"></param>
		/// <param name="addParamsCallback"></param>
		/// <returns></returns>
		protected virtual string GetPostResponseJson(string postJson, Action<IDictionary<string, object>> addParamsCallback)
		{
			// Build the URL
			string url = Configuration.ApiWriteUrl;

			Debug.WriteLine(String.Format("POSTing request to URL '{0}' with json: {1} ", url, postJson));

			// Generate post objects
			Dictionary<string, object> postParameters = new Dictionary<string, object>();

			postParameters.Add("json", postJson);

			if (addParamsCallback != null)
			{
				addParamsCallback(postParameters);
			}

			const string userAgent = "Brightcove .NET MAPI Wrapper";

			HttpWebRequest request = FormUploadUtil.BuildMultipartFormDataPostRequest(RequestBuilder, url, userAgent, postParameters, Configuration.RequestTimeout);
			string json = PerformRequest(request);

			Debug.WriteLine(String.Format("JSON Response: \n{0}", json));

			return json;
		}

		/// <summary>
		/// Performs the specified HttpWebRequest
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		protected virtual string PerformRequest(HttpWebRequest request)
		{
			Debug.WriteLine(String.Format("Performing request. Timeout is {0}.", request.Timeout));

			string json;
			try
			{
				using (HttpWebResponse response = (HttpWebResponse) request.GetResponse())
				using (Stream responseStream = response.GetResponseStream())
				{
					json = ReadResponse(responseStream);
				}
			} 
			catch (Exception e)
			{
				throw new BrightcoveApiException("An exception was encountered while performing the API request.", e);
			}
			return json;
		}

		/// <summary>
		/// Reads the entirety of the specified stream
		/// </summary>
		/// <param name="responseStream"></param>
		/// <returns></returns>
		protected virtual string ReadResponse(Stream responseStream)
		{
			if (responseStream == null)
			{
				throw new ArgumentNullException("responseStream"); //NOTE: Resharper seems to think this might happen, but I doubt it.
			}

			using (TextReader reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
