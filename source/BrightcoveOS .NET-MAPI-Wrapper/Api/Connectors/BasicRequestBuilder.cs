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
		///  multipart upload orginal source: http://stackoverflow.com/questions/566462/upload-files-with-httpwebrequest-multipart-form-data
		///  Author: 	Cristian Romanescu  http:/www.romanescu.ro
		/// </remarks>
		public virtual HttpWebRequest BuildMultipartFormDataPostRequest(string postUrl, string fileToPost, NameValueCollection postParameters)
		{
				string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                HttpWebRequest wr = BuildRequest(postUrl);
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;
                wr.Credentials = System.Net.CredentialCache.DefaultCredentials;

                Stream rs = wr.GetRequestStream();

                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                foreach (string key in postParameters.Keys)
                {
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string formitem = string.Format(formdataTemplate, key, postParameters[key]);
                    byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(formitem);
                    rs.Write(formitembytes, 0, formitembytes.Length);
                }
                rs.Write(boundarybytes, 0, boundarybytes.Length);

                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
		        var fileName = new FileInfo(fileToPost).Name;
                string header = string.Format(headerTemplate, "file", fileName, "application/octet-stream");
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                using (FileStream fileStream = new FileStream(fileToPost, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = 0;
                    while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        rs.Write(buffer, 0, bytesRead);
                    }
                }

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
                rs.Close();

		        return wr;
		}

	}
}
