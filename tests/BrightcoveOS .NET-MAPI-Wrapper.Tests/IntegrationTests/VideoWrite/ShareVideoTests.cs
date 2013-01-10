using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class ShareVideoTests : VideoWriteTestBase
	{
		[Test]
		public void ShareVideo_Basic()
		{
			// Values from: http://docs.brightcove.com/en/media/samples/share_video.html
			long publisherId = 57838016001;
			long videoToShareId = 1939641133001;
			ICollection<long> resultIds = _api.ShareVideo(videoToShareId, true, true, new[] { publisherId });

			Assert.That(resultIds, Is.Not.Null);
			Assert.That(resultIds.Count, Is.GreaterThan(0));
			Assert.That(resultIds.First(), Is.GreaterThan(0));
		}
	}
}
