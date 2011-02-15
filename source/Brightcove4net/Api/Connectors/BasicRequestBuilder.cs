using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Brightcove4net.Util;
using Brightcove4net.Util.Extensions;

namespace Brightcove4net.Api.Connectors
{
	/// <summary>
	/// A basic implementation of IRequestBuilder
	/// </summary>
	public class BasicRequestBuilder : IRequestBuilder
	{
		public BrightcoveApiConfig Configuration
		{
			get;
			set;
		}

		public BasicRequestBuilder(BrightcoveApiConfig configuration)
		{
			Configuration = configuration;
		}

		public virtual HttpWebRequest BuildRequest(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Timeout = Configuration.RequestTimeout;
			request.UserAgent = Configuration.UserAgent;
			return request;
		}
        
		public virtual HttpWebRequest BuildPostFormRequest(string postUrl, NameValueCollection postParameters)
		{
			HttpWebRequest request = BuildRequest(postUrl);
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			
			// write our parameters to the rquest stream
			using (Stream requestStream = request.GetRequestStream())
			{
				byte[] bytes = Configuration.Encoding.GetBytes(postParameters.ToQueryString());
				requestStream.Write(bytes, 0, bytes.Length);
			}

			return request;
		}

		/// <remarks>
		/// Much of this file upload implementation found was taken from a forum post (and then refactored a bit).
		/// The original post can be found here:
		/// http://forum.brightcove.com/t5/Media-APIs/ASP-NET-C-Upload-Create-Video-Example/td-p/3048
		/// but the original author of the code is unclear. 
		///
		/// Google the random number used as part of the
		/// "form-data boundary" (http://www.google.com/search?q=28947758029299) and one can see that this 
		/// code has been copied & pasted many times over between many projects, often without citing a source. 
		/// 
		/// It might be originally from here:
		/// http://stackoverflow.com/questions/219827/multipart-forms-from-c-client
		/// http://www.briangrinstead.com/blog/multipart-form-post-in-c
		/// 
		/// If so, thanks Brian Grinstead!
		/// </remarks>
		public virtual HttpWebRequest BuildMultipartFormDataPostRequest(string postUrl, NameValueCollection postParameters, FileParameter fileParameter)
		{
			const string formDataBoundary = "-----------------------------28947758029299";
			const string contentType = "multipart/form-data; boundary=" + formDataBoundary;

			byte[] formData = GetMultipartFormData(postParameters, fileParameter, formDataBoundary);

			HttpWebRequest request = BuildRequest(postUrl);

			// request properties
			request.Method = "POST";
			request.ContentType = contentType;
			request.CookieContainer = new CookieContainer();
			request.ContentLength = formData.Length;

			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(formData, 0, formData.Length);
				requestStream.Close();
			}

			return request;
		}

		protected virtual byte[] GetMultipartFormData(NameValueCollection postParameters, FileParameter fileParameter, string boundary)
		{
			using(Stream formDataStream = new MemoryStream())
			{
				// handle the regular parameters
				foreach (string key in postParameters)
				{
					string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n",
					                                boundary,
					                                key,
					                                postParameters[key]);
					formDataStream.Write(Configuration.Encoding.GetBytes(postData), 0, postData.Length);
				}


				if (fileParameter != null)
				{
					// handle the file parameter
					// Add just the first part of this param, since we will write the file data directly to the Stream
					string header =
						string.Format(
							"--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
							boundary,
							"file",
							fileParameter.FileName ?? "file",
							fileParameter.ContentType ?? "application/octet-stream");

					formDataStream.Write(Configuration.Encoding.GetBytes(header), 0, header.Length);

					// Write the file data directly to the Stream, rather than serializing it to a string.
					formDataStream.Write(fileParameter.File, 0, fileParameter.File.Length);
				}

				// Add the end of the request
				string footer = "\r\n--" + boundary + "--\r\n";
				formDataStream.Write(Configuration.Encoding.GetBytes(footer), 0, footer.Length);

				// Dump the Stream into a byte[]
				formDataStream.Position = 0;
				byte[] formData = new byte[formDataStream.Length];
				formDataStream.Read(formData, 0, formData.Length);
				return formData;
			}
		}
	}
}
