using System;
using System.Collections.Generic;
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
			BrightcovePlaylist playlist = _api.FindPlaylistById(1963943649001);
			Assert.NotNull(playlist);

			playlist.Name = "Renamed Test Playlist";
			playlist.ShortDescription = "New short description";
			playlist.PlaylistType = PlaylistType.Explicit;

			long vidId = 1964441418001;

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
	}
}
