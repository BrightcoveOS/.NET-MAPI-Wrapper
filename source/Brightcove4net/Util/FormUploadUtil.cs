using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Brightcove4net.Util
{
	/// <summary>
	/// This class is used to post the bytes from a selected file to the Brightcove API.
	/// 
	/// Taken from a forum post that can be found here
	/// http://forum.brightcove.com/t5/Media-APIs/ASP-NET-C-Upload-Create-Video-Example/td-p/3048
	/// but the original author of the code is unclear. Google the random number used as part of the
	/// "form-data boundary" (http://www.google.com/search?q=28947758029299) and one can see that this 
	/// code has been copied & pasted many times over between many projects, often without citing a source. 
	/// 
	/// It might be originally from here:
	/// http://stackoverflow.com/questions/219827/multipart-forms-from-c-client
	/// http://www.briangrinstead.com/blog/multipart-form-post-in-c
	/// 
	/// If so, thanks Brian Grinstead!
	/// </summary>
	public static class FormUploadUtil
	{
		private static readonly Encoding _encoding = Encoding.UTF8;

		public static HttpWebRequest BuildMultipartFormDataPostRequest(string postUrl, string userAgent,
		                                                    Dictionary<string, object> postParameters)
		{
			string formDataBoundary = "-----------------------------28947758029299";
			string contentType = "multipart/form-data; boundary=" + formDataBoundary;

			byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

			return BuildPostFormRequest(postUrl, userAgent, contentType, formData);
		}

		private static HttpWebRequest BuildPostFormRequest(string postUrl, string userAgent, string contentType, byte[] formData)
		{
			HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;

			if (request == null)
			{
				throw new NullReferenceException("request is not a http request");
			}

			// Set up the request properties
			request.Method = "POST";
			request.ContentType = contentType;
			request.UserAgent = userAgent;
			request.CookieContainer = new CookieContainer();
			request.ContentLength = formData.Length; // We need to count how many bytes we're sending. 

			using (Stream requestStream = request.GetRequestStream())
			{
				// Push it out there
				requestStream.Write(formData, 0, formData.Length);
				requestStream.Close();
			}

			return request;
		}

		private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
		{
			Stream formDataStream = new MemoryStream();

			foreach (var param in postParameters)
			{
				if (param.Value is FileParameter)
				{
					FileParameter fileToUpload = (FileParameter) param.Value;

					// Add just the first part of this param, since we will write the file data directly to the Stream
					string header =
						string.Format(
							"--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
							boundary,
							param.Key,
							fileToUpload.FileName ?? param.Key,
							fileToUpload.ContentType ?? "application/octet-stream");

					formDataStream.Write(_encoding.GetBytes(header), 0, header.Length);

					// Write the file data directly to the Stream, rather than serializing it to a string.
					formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
				}
				else
				{
					string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}\r\n",
					                                boundary,
					                                param.Key,
					                                param.Value);
					formDataStream.Write(_encoding.GetBytes(postData), 0, postData.Length);
				}
			}

			// Add the end of the request
			string footer = "\r\n--" + boundary + "--\r\n";
			formDataStream.Write(_encoding.GetBytes(footer), 0, footer.Length);

			// Dump the Stream into a byte[]
			formDataStream.Position = 0;
			byte[] formData = new byte[formDataStream.Length];
			formDataStream.Read(formData, 0, formData.Length);
			formDataStream.Close();

			return formData;
		}

		public class FileParameter
		{
			public byte[] File { get; set; }
			public string FileName { get; set; }
			public string ContentType { get; set; }

			public FileParameter(byte[] file) : this(file, null)
			{
			}

			public FileParameter(byte[] file, string filename) : this(file, filename, null)
			{
			}

			public FileParameter(byte[] file, string filename, string contenttype)
			{
				File = file;
				FileName = filename;
				ContentType = contenttype;
			}
		}

		public static string CalculateMd5Hash(string filePath)
		{
			return CalculateMd5Hash(new FileInfo(filePath));
		}

		public static string CalculateMd5Hash(FileInfo fileInfo)
		{
			StringBuilder sb = new StringBuilder();

			using (MD5 md5Hasher = MD5.Create())
			using (FileStream fs = fileInfo.OpenRead())
			{
				foreach (Byte b in md5Hasher.ComputeHash(fs))
				{
					sb.Append(b.ToString("x2").ToLower());
				}
			}

			return sb.ToString();
		}
	}
}