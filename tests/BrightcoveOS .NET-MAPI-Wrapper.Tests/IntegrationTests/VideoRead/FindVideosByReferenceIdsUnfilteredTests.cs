using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindVideosByReferenceIdsUnfilteredTests : VideoReadTestBase
	{
		/// <summary>
		/// Will throw an exception as the test token does not have unfiltered access.
		/// </summary>
		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void FindVideosByReferenceIds_Basic()
		{
			List<string> ids = new List<string>
			                   	{
			                   		"1939643268001",
									"1964441415001"
			                   	};

			_videos = _api.FindVideosByReferenceIdsUnfiltered(ids);

			Assert.AreEqual(2, _videos.Count);
			Assert.AreEqual(0, _videos.Count(o => o == null));
		}
	}
}
