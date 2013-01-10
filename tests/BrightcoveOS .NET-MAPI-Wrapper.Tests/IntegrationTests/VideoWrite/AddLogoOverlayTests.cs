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
	public class AddLogoOverlayTests : VideoWriteTestBase
	{
		/// <summary>
		/// Test image is from the wikimedia commons: http://commons.wikimedia.org/wiki/File:TEST%3F.png
		/// </summary>
		private string FileToUpload = "..\\..\\Assets\\test-image.png";

		[Test]
		public void AddLogoOverlay_Test_Basic()
		{
			BrightcoveImage image = new BrightcoveImage();
			image.Type = ImageType.LogoOverlay;

			BrightcoveLogoOverlay logoOverlay = new BrightcoveLogoOverlay();
			logoOverlay.Image = image;

			_api.AddLogoOverlay(logoOverlay, FileToUpload, 1942305739001);

			// TODO: not sure how to verify this worked other than the lack of error
		}
	}
}
