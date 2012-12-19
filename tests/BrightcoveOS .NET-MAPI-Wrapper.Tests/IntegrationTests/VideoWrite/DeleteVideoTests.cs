using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class DeleteVideoTests : VideoWriteTestBase
	{
		[Test]
		public void DeleteVideo_Test_Basic()
		{
			long videoId = 1939484105001; // test video from http://docs.brightcove.com/en/media/samples/delete_video.html

			// delete it
			_api.DeleteVideo(videoId, true, true);

			// verify it's gone
			Assert.IsNull(_api.FindVideoById(videoId));
		}
	}
}
