using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using BrightcoveMapiWrapper.Util;
using BrightcoveMapiWrapper.Util.Extensions;

namespace BrightcoveMapiWrapper.Api.Connectors
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
		public virtual HttpWebRequest BuildMultipartFormDataPostRequest(string postUrl, NameValueCollection postParameters, FileUploadInfo fileToUpload)
		{
			string boundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x");
			string contentType = "multipart/form-data; boundary=" + boundary;

			HttpWebRequest request = BuildRequest(postUrl);

			// request properties
			request.Method = "POST";
			request.ContentType = contentType;
			
			WriteMultipartFormData(request, postParameters, fileToUpload, boundary);

			return request;
		}

		protected virtual void WriteMultipartFormData(HttpWebRequest request, NameValueCollection postParameters, FileUploadInfo fileToUpload, string boundary)
		{
			// keep track of how much data we're sending
			long contentLength = 0;

			// encode the post parameters
			IList<byte[]> parameterBytes = new List<byte[]>();
			foreach (string key in postParameters)
			{
				string paramData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n",
				                                boundary,
				                                key,
				                                postParameters[key]);
				byte[] bytes = Configuration.Encoding.GetBytes(paramData);
				parameterBytes.Add(bytes);
				contentLength += bytes.Length;
			}

			// encode the footer
			string footer = "\r\n--" + boundary + "--\r\n";
			byte[] footerBytes = Configuration.Encoding.GetBytes(footer);
			contentLength += footerBytes.Length;	

			// file header 
			string fileHeader =
				string.Format(
					"--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
					boundary, "file", fileToUpload.FileName, fileToUpload.ContentType);
			byte[] fileHeaderBytes = Configuration.Encoding.GetBytes(fileHeader);
			contentLength += fileHeaderBytes.Length;

			// tell the request how much data to expect
			request.ContentLength = contentLength;

			// write everything to the request stream
			using (Stream requestStream = request.GetRequestStream())
			{
				// params 
				foreach (byte[] bytes in parameterBytes)
				{
					requestStream.Write(bytes, 0, bytes.Length);	
				}
				
				// file header
				requestStream.Write(fileHeaderBytes, 0, fileHeaderBytes.Length);
                               
				// file data
				byte[] buffer = new byte[4096];
				int bytesRead;
				while ((bytesRead = fileToUpload.FileData.Read(buffer, 0, buffer.Length)) > 0)
				{
					requestStream.Write(buffer, 0, bytesRead);
				}
			
				// footer
				requestStream.Write(footerBytes, 0, footerBytes.Length);
			}
		}
	}
}
