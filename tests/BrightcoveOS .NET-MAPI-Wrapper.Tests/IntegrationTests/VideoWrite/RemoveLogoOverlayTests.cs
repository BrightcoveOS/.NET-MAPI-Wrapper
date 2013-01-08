using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class RemoveLogoOverlayTests : VideoWriteTestBase
	{
		[Test]
		public void RemoveLogoOverlay_Test_Basic()
		{
			_api.RemoveLogoOverlay(1942305739001);

			// TODO: not sure how to verify this worked other than the lack of error
		}
	}
}
