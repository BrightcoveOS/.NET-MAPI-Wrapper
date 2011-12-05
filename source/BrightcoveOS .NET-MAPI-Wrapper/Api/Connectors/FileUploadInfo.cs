using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Api.Connectors
{
	public class FileUploadInfo
	{
		public Stream FileData { get; set; }
		public string FileName { get; set; }
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
