using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using BrightcoveMapiWrapper.Api.Connectors;

namespace BrightcoveMapiWrapper.Util
{
	/// <summary>
	/// Calculates an <see cref="MD5"/> hash for a given file.
	/// </summary>
	public static class FormUploadUtil
	{
		/// <summary>
		/// Calculates an <see cref="MD5"/> hash based on a given file path.
		/// </summary>
		/// <param name="filePath">The file path of a given file.</param>
		/// <returns>The string representation of the <see cref="MD5"/> hash.</returns>
		public static string CalculateMd5Hash(string filePath)
		{
			return CalculateMd5Hash(new FileInfo(filePath));
		}

		/// <summary>
		/// Calculates an <see cref="MD5"/> hash based on a given <see cref="FileInfo"/>.
		/// </summary>
		/// <param name="fileInfo">The <see cref="FileInfo"/> of a given file.</param>
		/// <returns>The string representation of the <see cref="MD5"/> hash.</returns>
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