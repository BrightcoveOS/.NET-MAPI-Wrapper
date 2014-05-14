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
			video.Name = "Test Video Creation: Uploaded File";
			video.ReferenceId = "test-reference-id";
			video.ShortDescription = "Test video, created via the API. Video is from the Creative Commons: http://creativecommons.org/videos/building-on-the-past";

			// Remove any previous videos using our test reference ID, or the CreateVideo call may fail due to a dupe ID
			DeleteExisting(video.ReferenceId);

			long newId = _api.CreateVideo(video, FileToUpload, EncodeTo.Mp4, false);
			Assert.That(newId, Is.GreaterThan(0));
		}

		[Test]
		public void CreateVideo_VideoFullLength()
		{
			BrightcoveVideo video = new BrightcoveVideo();
			video.Name = "Test Video Creation: RemoteUrl";
			video.ReferenceId = "test-reference-id";
			video.ShortDescription = "Test video, created via the API. Video is from the Creative Commons: http://creativecommons.org/videos/building-on-the-past";
			video.VideoFullLength = new BrightcoveRendition
				{
					RemoteUrl = "http://blip.tv/file/get/Commonscreative-BuildingOnThePast896.mov",
					ControllerType = ControllerType.Default,
					VideoCodec = VideoCodec.H264
				};

			DeleteExisting(video.ReferenceId);

			long newId = _api.CreateVideo(video);
			Assert.That(newId, Is.GreaterThan(0));
		}

		private void DeleteExisting(string referenceId)
		{
			// Remove any previous videos using our test reference ID, or the CreateVideo call may fail due to a dupe ID
			// FindVideoByReferenceId results are cached and may be outdated, so just fire off a delete request and ignore errors.
			try
			{
				_api.DeleteVideo(referenceId, true, true);
			}
			catch { }
		}
	}
}
