using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistWrite
{
	[TestFixture]
	public class DeleteAudioTrackPlaylistTests : AudioTrackPlaylistWriteTestBase
	{
		[Test]
		public void DeleteAudioTrackPlaylistBasicTest_ByReferenceId()
		{
			var playlists = _api.FindAllAudioTrackPlaylists();
			var playlist = playlists.First();

			_api.DeleteAudioTrackPlaylist(playlist.ReferenceId, true);

			var deletedPlaylist = _api.FindAudioTrackById(playlist.Id);
			// Should be null after the deletion, but you may get the cached version at times. (?)
			Assert.AreEqual(null, deletedPlaylist);
		}
	}
}
