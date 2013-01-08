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
	public class FindModifiedVideosTests : VideoReadTestBase
	{
		[Test]
		public void FindModifiedVideos_Basic()
		{
			_videos = _api.FindModifiedVideos(DateTime.Now.AddMonths(-2), null, 1, 0);

			Assert.Greater(_videos.Count, 0);
		}
	}
}
