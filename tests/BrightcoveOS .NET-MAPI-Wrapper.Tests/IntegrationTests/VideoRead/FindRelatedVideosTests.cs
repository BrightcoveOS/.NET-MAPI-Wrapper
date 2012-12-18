using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindRelatedVideosTests
	{
		private BrightcoveApi _api;
		private BrightcoveItemCollection<BrightcoveVideo> _videos;

		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.VideoReadKey);
		}

		[Test]
		public void FindRelatedVideosByReferenceId_Basic()
		{
			_videos = _api.FindRelatedVideosByReferenceId("1939643268001");

			// make sure we have at least one result
			Assert.Greater(_videos.Count, 0);
		}

		[Test]
		public void FindRelatedVideosById_Basic()
		{
			_videos = _api.FindRelatedVideosById(1939643268001);

			// make sure we have at least one result
			Assert.Greater(_videos.Count, 0);
		}
	}
}
