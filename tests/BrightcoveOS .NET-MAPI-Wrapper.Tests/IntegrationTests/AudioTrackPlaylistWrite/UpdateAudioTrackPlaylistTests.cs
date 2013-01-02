using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistWrite
{
	[TestFixture]
	public class UpdateAudioTrackPlaylistTests : AudioTrackPlaylistWriteTestBase
	{
		[Test]
		public void UpdateAudioTrackPlaylist_Test_Basic()
		{
			BrightcoveAudioTrackPlaylist playlist = _api.FindAudioTrackPlaylistByReferenceId(_refId);
			playlist.Name = "Renamed Test Audio Playlist";
			playlist.ShortDescription = "This is a playlist's NEW short description";

			BrightcoveAudioTrackPlaylist returnedPlaylist = _api.UpdateAudioTrackPlaylist(playlist);

			Assert.AreEqual(playlist.Name, returnedPlaylist.Name);
			Assert.AreEqual(playlist.ShortDescription, returnedPlaylist.ShortDescription);
			Assert.AreEqual(playlist.AudioTrackIds.Count, returnedPlaylist.AudioTrackIds.Count);
		}
	}
}
