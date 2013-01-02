using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{
	[TestFixture]
	public class FindAudioTracksByIdsTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindAudioTracksByIds_Test_Basic()
		{
			// Rather than hardcoding a list of ids, dynamically fetch the first 5 ids
			// of the videos on the first page of the FindAllAudioTracks result.
			long[] ids = _api.FindAllAudioTracks(5, 0).Select(x => x.Id).ToArray();

			// Now, actually check the call you really want to test.
			_audioTracks = _api.FindAudioTracksByIds(ids);

			Assert.AreEqual(ids.Length, _audioTracks.Count);
			Assert.AreEqual(0, _audioTracks.Count(o => o == null));
		}
	}
}
