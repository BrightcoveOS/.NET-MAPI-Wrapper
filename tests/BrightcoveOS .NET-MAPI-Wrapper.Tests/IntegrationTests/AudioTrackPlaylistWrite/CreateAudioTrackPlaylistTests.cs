using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Containers;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistWrite
{
	[TestFixture]
	public class CreateAudioTrackPlaylistTests : AudioTrackPlaylistWriteTestBase
	{
		[Test]
		public void CreateAudioTrackPlaylist_Test_Basic()
		{
			BrightcoveItemCollection<BrightcoveAudioTrack> audioTracks = _api.FindAllAudioTracks(3, 0);
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = _refId,
				// Get a list of three random audio tracks to add to the playlist.
				AudioTrackIds = audioTracks.Select(x => x.Id).ToList(),
				ShortDescription = "This is a playlist's short description"
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			BrightcoveAudioTrackPlaylist newPlaylist = _api.FindAudioTrackPlaylistById(newId);

			Assert.AreEqual(playlist.Name, newPlaylist.Name);
			Assert.AreEqual(playlist.ReferenceId, newPlaylist.ReferenceId);
			Assert.AreEqual(playlist.ShortDescription, newPlaylist.ShortDescription);
			Assert.AreEqual(audioTracks.Count, newPlaylist.AudioTrackIds.Count);
			Assert.AreEqual(audioTracks.Count, newPlaylist.AudioTracks.Count);
			Assert.AreEqual(audioTracks.Count, newPlaylist.AudioTracks.Count(o => o != null));
		}
	}
}
