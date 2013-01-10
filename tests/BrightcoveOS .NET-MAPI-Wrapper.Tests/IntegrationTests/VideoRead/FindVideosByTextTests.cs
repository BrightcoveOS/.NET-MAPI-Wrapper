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
	public class FindVideosByTextTests : VideoReadTestBase
	{
		[Test]
		public void FindVideosByText_Basic()
		{
#pragma warning disable 612,618
			_videos = _api.FindVideosByText("test");
#pragma warning restore 612,618

			Assert.Greater(_videos.Count, 0);
		}
	}
}
