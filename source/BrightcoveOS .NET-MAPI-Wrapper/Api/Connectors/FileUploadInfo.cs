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

		/// <summary>
		/// Initializes a new instance of the <see cref="FileUploadInfo" /> class.
		/// </summary>
		/// <param name="data">The data to upload.</param>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="contentType">Type of the content.</param>
		public FileUploadInfo(Stream data, string fileName, string contentType)
		{
			FileData = data;
			FileName = fileName;
			ContentType = contentType;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FileUploadInfo" /> class.
		/// </summary>
		/// <param name="data">The data to upload.</param>
		/// <param name="fileName">Name of the file.</param>
		public FileUploadInfo(Stream data, string fileName)
			: this(data, fileName, "application/octet-stream")
		{
		}
	}
}
