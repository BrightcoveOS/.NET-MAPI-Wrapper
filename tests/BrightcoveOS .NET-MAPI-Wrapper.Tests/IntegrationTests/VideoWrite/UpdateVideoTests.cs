using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class UpdateVideoTests : VideoWriteTestBase
	{
		private long _videoId = 1939484101001;

		[Test]
		public void UpdateVideo_Test_Basic()
		{
			BrightcoveVideo video = _api.FindVideoById(_videoId);
			video.Name = "Sea-SeaTurtle (updated)";
			video.ShortDescription = "Sea-SeaTurtle (updated description)";
			
			BrightcoveVideo returnedVideo = _api.UpdateVideo(video);
			Assert.AreEqual(video.Name, returnedVideo.Name);
			Assert.AreEqual(video.ShortDescription, returnedVideo.ShortDescription);
		}

		[Test]
		public void UpdateVideo_Test_Dates()
		{
			BrightcoveVideo video = _api.FindVideoById(_videoId);
			DateTime yesterday = DateTime.Now.AddDays(-1);
			DateTime tomorrow = DateTime.Now.AddDays(1);
			video.StartDate = yesterday;
			video.EndDate = tomorrow;

			BrightcoveVideo returnedVideo = _api.UpdateVideo(video); // won't show the newly updated dates, so we have to make a separate call
			BrightcoveVideo foundVideo = _api.FindVideoById(video.Id, new[] { "endDate", "startDate" });
			Assert.AreEqual(yesterday.ToString(), foundVideo.StartDate.ToString());
			Assert.AreEqual(tomorrow.ToString(), foundVideo.EndDate.ToString());
		}

		[Test]
		public void UpdateVideo_Test_CuePoints()
		{
			BrightcoveVideo video = _api.FindVideoById(_videoId);
			BrightcoveCuePoint cuePoint = new BrightcoveCuePoint
			{
				Name = "Test Cue Point",
				Time = 10000 // 10 seconds in
			};

			video.CuePoints.Add(cuePoint);

			BrightcoveVideo returnedVideo = _api.UpdateVideo(video); // won't show the newly updated cue points, so we have to make a separate call
			BrightcoveVideo foundVideo = _api.FindVideoById(video.Id, new[] { "cuePoints" });
			Assert.Greater(foundVideo.CuePoints.Count, 0);
			Assert.AreEqual(cuePoint.Name, foundVideo.CuePoints.First().Name);
			Assert.AreEqual(cuePoint.Time, foundVideo.CuePoints.First().Time);
			Assert.AreEqual(cuePoint.Type, foundVideo.CuePoints.First().Type);
		}
	}
}
