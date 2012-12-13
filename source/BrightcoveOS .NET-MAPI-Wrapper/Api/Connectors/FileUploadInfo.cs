using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Api.Connectors
{
	/// <summary>
	/// Helper class used to store file upload information.
	/// </summary>
	public class FileUploadInfo
	{
		/// <summary>
		/// The data of the file stored in a stream.
		/// </summary>
		public Stream FileData { get; set; }
		/// <summary>
		/// The name of the file.
		/// </summary>
		public string FileName { get; set; }
		/// <summary>
		/// The content type of the file.
		/// </summary>
		public string ContentType { get; set; }

		public FileUploadInfo(Stream data, string fileName, string contentType)
		{
			FileData = data;
			FileName = fileName;
			ContentType = contentType;
		}

		public FileUploadInfo(Stream data, string fileName)
			: this(data, fileName, "application/octet-stream")
		{
		}
	}
}
