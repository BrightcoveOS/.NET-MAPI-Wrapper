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
	public class FindVideosByTagsTests : VideoReadTestBase
	{
		[Test]
		public void FindVideosByTags_Basic()
		{
			_videos = _api.FindVideosByTags(new[] { "test" }, null);

			Assert.Greater(_videos.Count, 0);
		}
	}
}
