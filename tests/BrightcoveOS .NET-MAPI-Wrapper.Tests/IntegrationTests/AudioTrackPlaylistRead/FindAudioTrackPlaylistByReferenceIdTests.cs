using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistRead
{
	[TestFixture]
	public class FindAudioTrackPlaylistByReferenceIdTests : AudioTrackPlaylistReadTestBase
	{
		[Test]
		public void FindAudioTrackPlaylistByReferenceId_Basic_Test()
		{
			BrightcoveAudioTrackPlaylist playlist = _api.FindAudioTrackPlaylistByReferenceId(_refId);

			// Happens to contain 3 videos.
			Assert.NotNull(playlist);
			Assert.AreEqual(3, playlist.AudioTrackIds.Count);
			Assert.AreEqual(3, playlist.AudioTracks.Count);
			Assert.AreEqual(3, playlist.AudioTracks.Count(o => o != null));
		}

	}
}
