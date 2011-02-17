using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using BrightcoveMapiWrapper.Api.Connectors;

namespace BrightcoveMapiWrapper.Util
{
	public static class FormUploadUtil
	{
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