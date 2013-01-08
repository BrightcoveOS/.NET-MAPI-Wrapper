using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{
	[TestFixture]
	public class FindModifiedAudioTracksTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindModifiedAudioTracks_Test_Basic()
		{
			_audioTracks = _api.FindModifiedAudioTracks(DateTime.UtcNow.AddMonths(-2));

			Assert.Greater(_audioTracks.Count, 0);
			Assert.AreEqual(0, _audioTracks.Count(o => o == null));
		}
	}
}
