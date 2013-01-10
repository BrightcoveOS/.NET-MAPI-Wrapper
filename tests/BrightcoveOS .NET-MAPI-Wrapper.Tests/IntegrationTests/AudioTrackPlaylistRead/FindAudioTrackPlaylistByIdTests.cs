using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistRead
{
	[TestFixture]
	public class FindAudioTrackPlaylistByIdTests : AudioTrackPlaylistReadTestBase
	{
		[Test]
		public void FindAudioTrackPlaylistById_NonExistent_Test()
		{
			_playlists = _api.FindAllAudioTrackPlaylists(1, 0);
			BrightcoveAudioTrackPlaylist playlist = _api.FindAudioTrackPlaylistById(_playlists.First().Id);
			Assert.AreEqual(3, playlist.AudioTracks.Count);
		}
	}
}
