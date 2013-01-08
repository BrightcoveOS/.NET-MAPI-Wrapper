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
	public class FindVideosByIdsTests : VideoReadTestBase
	{
		[Test]
		public void FindVideosByIds_Basic()
		{
			List<long> ids = new List<long>
			{
				1964394725001,
				1964394737001
			};

			_videos = _api.FindVideosByIds(ids);

			Assert.AreEqual(ids.Count, _videos.Count);
			Assert.AreEqual(0, _videos.Count(o => o == null));
		}
	}
}
