using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{
	[TestFixture]
	public class FindAudioTracksByTagsTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindAudioTracksByTags_Test_Basic()
		{
			_audioTracks = _api.FindAudioTracksByTags(new string[]{}, new[] { "president" });

			Assert.Greater(_audioTracks.Count, 0);
			Assert.AreEqual(0, _audioTracks.Count(o => o == null));
		}
	}
}
