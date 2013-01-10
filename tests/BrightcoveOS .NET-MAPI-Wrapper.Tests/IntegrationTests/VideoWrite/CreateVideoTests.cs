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
	public class CreateVideoTests : VideoWriteTestBase
	{
		/// <summary>
		/// Test video is from the Creative Commons: http://creativecommons.org/videos/building-on-the-past
		/// </summary>
		private string FileToUpload = "..\\..\\Assets\\Building_On_The_Past.mov";

		[Test]
		public void CreateVideo_Test_Basic()
		{
			BrightcoveVideo video = new BrightcoveVideo();
			video.Name = "Test Video Creation";
			video.ReferenceId = "test-reference-id";
			video.ShortDescription = "Test video, created via the API. Video is from the Creative Commons: http://creativecommons.org/videos/building-on-the-past";

			long newId = _api.CreateVideo(video, FileToUpload, EncodeTo.Mp4, false);
			Assert.That(newId, Is.GreaterThan(0));
		}
	}
}
