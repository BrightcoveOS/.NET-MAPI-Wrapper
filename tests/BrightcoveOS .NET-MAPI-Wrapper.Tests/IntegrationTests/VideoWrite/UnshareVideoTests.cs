using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class UnshareVideoTests : VideoWriteTestBase
	{
		[Test]
		public void UnshareVideo_Basic()
		{
			// Values from: http://docs.brightcove.com/en/media/samples/unshare_video.html
			const long publisherId = 57838016001;
			const long videoToShareId = 1939641133001;
			ICollection<long> resultIds = _api.UnshareVideo(videoToShareId, new[] { publisherId });

			Assert.That(resultIds, Is.Not.Null);
		}
	}
}
