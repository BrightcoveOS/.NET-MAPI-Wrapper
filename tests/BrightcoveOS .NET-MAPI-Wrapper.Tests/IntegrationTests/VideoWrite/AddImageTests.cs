using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class AddImageTests : VideoWriteTestBase
	{
		/// <summary>
		/// Test image is from the wikimedia commons: http://commons.wikimedia.org/wiki/File:TEST%3F.png
		/// </summary>
		private string FileToUpload = "..\\..\\Assets\\test-image.png";

		[Test]
		public void AddImage_Test_Basic()
		{
			BrightcoveImage image = new BrightcoveImage();
			image.Type = ImageType.Thumbnail;

			_api.AddImage(image, FileToUpload, 1942305739001);

			// TODO: not sure how to verify this worked other than the lack of error
		}

		[Test]
		public void AddImage_Test_VideoRefId()
		{
			BrightcoveImage image = new BrightcoveImage();
			image.Type = ImageType.Thumbnail;

			_api.AddImage(image, FileToUpload, "1942305739001");

			// TODO: not sure how to verify this worked other than the lack of error
		}
	}
}
