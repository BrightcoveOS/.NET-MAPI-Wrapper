using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Web;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{
	[TestFixture]
	public class FindAudioTracksByReferenceIdsTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindAudioTracksByReferenceIds_Test_Basic()
		{
			// Rather than hardcoding a list of ids, dynamically fetch the first 5 ids
			// of the videos on the first page of the FindAllAudioTracks result.
			string[] ids = _api.FindAllAudioTracks(5, 0).Select(x => x.ReferenceId).ToArray();

			// Now, actually check the call you really want to test.
			_audioTracks = _api.FindAudioTracksByReferenceIds(ids);

			Assert.AreEqual(ids.Length, _audioTracks.Count);
			Assert.AreEqual(0, _audioTracks.Count(o => o == null));
		}
	}
}
