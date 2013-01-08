using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Containers;

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

		[Test]
		public void UpdateAudioTrackPlaylist_Test_Change_From_Explicit_To_Smart()
		{
			BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> playlists = _api.FindAllAudioTrackPlaylists();

			// look for the first Explicit playlist
			BrightcoveAudioTrackPlaylist playlist = playlists.FirstOrDefault(x => x.PlaylistType == PlaylistType.Explicit);
			if (playlist == null)
			{
				Assert.Fail("There are no explicit playlists in the collection. Try creating an explicit playlist first.");
			}
			else
			{
				// Make a smart playlist of any sort.
				playlist.PlaylistType = PlaylistType.Alphabetical;
				BrightcoveAudioTrackPlaylist updatedPlaylist = _api.UpdateAudioTrackPlaylist(playlist);
				Assert.AreEqual(playlist.PlaylistType, updatedPlaylist.PlaylistType);
			}
		}

		[Test]
		public void UpdateAudioTrackPlaylist_Test_Change_From_Smart_To_Explicit()
		{
			BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> playlists = _api.FindAllAudioTrackPlaylists();

			// look for the first NON-Explicit playlist (smart)
			BrightcoveAudioTrackPlaylist playlist = playlists.FirstOrDefault(x => x.PlaylistType != PlaylistType.Explicit);
			if (playlist == null)
			{
				Assert.Fail("There are no smart playlists in the collection. Try creating an smart playlist first.");
			}
			else
			{
				// If it doesn't have any audio tracks, add some to test the inclusion of the VideoIds property.
				if (!playlist.AudioTrackIds.Any())
				{
					BrightcoveItemCollection<BrightcoveAudioTrack> audioTracks = _api.FindAllAudioTracks(4, 0);
					playlist.AudioTrackIds = audioTracks.Select(x => x.Id).ToList();
				}

				// Make an explicit playlist.
				playlist.PlaylistType = PlaylistType.Explicit;
				
				//Apply workaround.
				ICollection<long> audioTracksIds = playlist.AudioTrackIds;
				playlist.AudioTrackIds = new Collection<long>();

				BrightcoveAudioTrackPlaylist updatedPlaylist = _api.UpdateAudioTrackPlaylist(playlist);
				Assert.AreEqual(playlist.PlaylistType, updatedPlaylist.PlaylistType);

				// Re-update playlist
				updatedPlaylist.AudioTrackIds = audioTracksIds;
				BrightcoveAudioTrackPlaylist reUpdatedPlaylist = _api.UpdateAudioTrackPlaylist(updatedPlaylist);
				Assert.AreEqual(audioTracksIds.Count, reUpdatedPlaylist.AudioTrackIds.Count);
			}
		}
	}
}
