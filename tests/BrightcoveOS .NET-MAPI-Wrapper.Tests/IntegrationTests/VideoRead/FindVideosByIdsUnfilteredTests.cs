using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BrightcoveMapiWrapper.Api;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindVideosByIdsUnfilteredTests : VideoReadTestBase
	{
		/// <summary>
		/// Will throw an exception as the test token does not have unfiltered access.
		/// </summary>
		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void FindVideosByIdsUnfiltered_Basic()
		{
			List<long> ids = new List<long>
			                   	{
			                   		1939643268001,
									1964441415001
			                   	};

			_videos = _api.FindVideosByIdsUnfiltered(ids);

			Assert.AreEqual(2, _videos.Count);
			Assert.AreEqual(0, _videos.Count(o => o == null));
		}
	}
}
