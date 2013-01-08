using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistWrite
{
	[TestFixture]
	public class UpdatePlaylistTests : PlaylistWriteTestBase
	{
		[Test]
		public void UpdatePlaylist_Test_Basic()
		{
			BrightcovePlaylist playlist = _api.FindPlaylistById(1989037682001);
			Assert.NotNull(playlist);

			playlist.Name = "Renamed Test Playlist";
			playlist.ShortDescription = "New short description";
			playlist.PlaylistType = PlaylistType.Explicit;

			const long vidId = 1964441418001;

			// Remove or add the video, depending on whether it was already there
			bool isPresent = !playlist.VideoIds.Contains(vidId);
			if (isPresent)
			{
				playlist.VideoIds.Remove(vidId);
			}
			else
			{
				playlist.VideoIds.Add(vidId);
			}

			BrightcovePlaylist returnedPlaylist = _api.UpdatePlaylist(playlist);
			Assert.AreEqual(playlist.Name, returnedPlaylist.Name);
			Assert.AreEqual(playlist.ShortDescription, returnedPlaylist.ShortDescription);
			Assert.AreEqual(playlist.VideoIds.Count, returnedPlaylist.VideoIds.Count);

			if (isPresent)
			{
				Assert.That(returnedPlaylist.VideoIds, Is.Not.Contains(vidId));
			}
			else
			{
				Assert.That(returnedPlaylist.VideoIds, Contains.Item(vidId));
			}
		}

		[Test]
		public void UpdatePlaylist_Change_From_Explicit_To_Smart_Test()
		{
			BrightcoveItemCollection<BrightcovePlaylist> playlists = _api.FindAllPlaylists();

			// Look for the first Explicit playlist.
			BrightcovePlaylist playlist = playlists.LastOrDefault(x => x.PlaylistType == PlaylistType.Explicit);
			if (playlist == null)
			{
				Assert.Fail("There are no explicit playlists in the collection. Try creating an explicit playlist first.");
			}
			else
			{
				// If it doesn't have any videos, add some to test the inclusion of the VideoIds property.
				if (!playlist.VideoIds.Any())
				{
					BrightcoveItemCollection<BrightcoveVideo> videos = _api.FindAllVideos(4, 0);
					playlist.VideoIds = videos.Select(x => x.Id).ToList();
				}

				// Make a smart playlist of any sort.
				playlist.PlaylistType = PlaylistType.PlaysTotal;
				BrightcovePlaylist updatedPlaylist = _api.UpdatePlaylist(playlist);
				Assert.AreEqual(PlaylistType.PlaysTotal, updatedPlaylist.PlaylistType);
			}
		}

		[Test]
		public void UpdatePlaylist_Change_From_Smart_To_Explicit_Test()
		{
			BrightcoveItemCollection<BrightcovePlaylist> playlists = _api.FindAllPlaylists();

			// Look for the first NON-explicit (i.e. smart) playlist.
			BrightcovePlaylist playlist = playlists.FirstOrDefault(x => x.PlaylistType != PlaylistType.Explicit);
			if (playlist == null)
			{
				Assert.Fail("There are no smart playlists in the collection. Try creating an smart playlist first.");
			}
			else
			{
				// If it doesn't have any videos, add some to test the inclusion of the VideoIds property.
				if (!playlist.VideoIds.Any())
				{
					BrightcoveItemCollection<BrightcoveVideo> videos = _api.FindAllVideos(4, 0);
					playlist.VideoIds = videos.Select(x => x.Id).ToList();
				}

				// Make an explicit playlist.
				playlist.PlaylistType = PlaylistType.Explicit;
				ICollection<long> videoIds = playlist.VideoIds;
				playlist.VideoIds = new Collection<long>();

				BrightcovePlaylist updatedPlaylist = _api.UpdatePlaylist(playlist);
				Assert.AreEqual(playlist.PlaylistType, updatedPlaylist.PlaylistType);

				updatedPlaylist.VideoIds = videoIds;
				BrightcovePlaylist newUpdatedPlaylist = _api.UpdatePlaylist(updatedPlaylist);
				Assert.AreEqual(videoIds.Count, newUpdatedPlaylist.VideoIds.Count);
			}
		}
	}
}
