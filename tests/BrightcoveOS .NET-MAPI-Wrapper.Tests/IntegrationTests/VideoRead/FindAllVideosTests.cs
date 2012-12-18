using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindAllVideosTests : VideoReadTestBase
	{
		[Test]
		public void FindAllVideos_Test_Basic()
		{
			_videos = _api.FindAllVideos();

			// We're testing against the public brightcove demo account, which has over 100 videos, 
			// so should expect a full page of videos
			Assert.AreEqual(100, _videos.Count);
		}

		[Test]
		public void FindAllVideos_Test_PageSize()
		{
			_videos = _api.FindAllVideos(10, 0);
			Assert.AreEqual(10, _videos.Count);
			Assert.AreEqual(10, _videos.PageSize);
		}

		[Test]
		public void FindAllVideos_Test_PageNum()
		{
			_videos = _api.FindAllVideos(10, 1, SortBy.CreationDate);

			Assert.AreEqual(1, _videos.PageNumber);
		}

		[Test]
		public void FindAllVideos_Test_Sort()
		{
			_videos = _api.FindAllVideos(10, 0, SortBy.CreationDate);
			Assert.AreEqual(10, _videos.Count);

			// verify each video's creation date is in order
			BrightcoveVideo lastVideo = null;
			foreach (BrightcoveVideo bcVideo in _videos)
			{
				if (lastVideo == null)
				{
					lastVideo = bcVideo;
					continue;
				}
				Assert.LessOrEqual(lastVideo.CreationDate, bcVideo.CreationDate);
				lastVideo = bcVideo;
			}
		}

		[Test]
		public void FindAllVideos_Test_SortOrder()
		{
			_videos = _api.FindAllVideos(10, 0, SortBy.CreationDate, SortOrder.Descending);
			Assert.AreEqual(10, _videos.Count);

			BrightcoveItemCollection<BrightcoveVideo> videos = _api.FindAllVideos(10, 0, SortBy.PlaysTotal, SortOrder.Descending);

			// verify each video's creation date is in order
			BrightcoveVideo lastVideo = null;
			foreach (BrightcoveVideo bcVideo in _videos)
			{
				if (lastVideo == null)
				{
					lastVideo = bcVideo;
					continue;
				}
				Assert.GreaterOrEqual(lastVideo.CreationDate, bcVideo.CreationDate);
				lastVideo = bcVideo;
			}
		}

		[Test]
		public void FindAllVideos_Test_Fields()
		{
			_videos = _api.FindAllVideos(1, 0, SortBy.CreationDate, SortOrder.Descending, new List<string> { "id", "name", "shortDescription" });
			Assert.AreEqual(1, _videos.Count);
			BrightcoveVideo video = _videos.FirstOrDefault();

			// the 3 fields we specified should be present
			Assert.Greater(video.Id, 0);
			Assert.IsNotNullOrEmpty(video.Name);
			Assert.IsNotNullOrEmpty(video.ShortDescription);

			// other fields should not
			Assert.IsNullOrEmpty(video.LongDescription);
			Assert.IsNullOrEmpty(video.FlvUrl);
		}

		[Test]
		public void FindAllVideos_Test_Fields_Null_StartDate_Exception()
		{
			_videos = _api.FindAllVideos(1, 0, SortBy.CreationDate, SortOrder.Descending, new[] { "startDate" });
			Assert.AreEqual(1, _videos.Count);
			Assert.AreEqual(DateTime.MinValue, _videos[0].StartDate);
		}

		[Test]
		public void FindAllVideos_Test_GetCount()
		{
			_videos = _api.FindAllVideos(10, 0); // count is retrieved by default

			// just make sure the field is getting set
			Assert.Greater(_videos.TotalCount, 0);
		}
	}
}
