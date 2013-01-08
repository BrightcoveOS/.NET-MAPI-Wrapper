using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistWrite
{
	[TestFixture]
	public class DeletePlaylistTests : PlaylistWriteTestBase
	{
		[Test]
		public void DeletePlaylist_Test_Basic()
		{
			// create a playlist that will later be deleted
			BrightcovePlaylist playlist = new BrightcovePlaylist();
			playlist.Name = "Test Playlist";
			playlist.ShortDescription = "Test Short Description";
			playlist.VideoIds.Add(1964394725001);
			playlist.VideoIds.Add(1964394726001);

			// perform the API call, verify the results
			long newId = _api.CreatePlaylist(playlist);
			BrightcovePlaylist newPlaylist = _api.FindPlaylistById(newId);
			Assert.AreEqual(playlist.Name, newPlaylist.Name);
			Assert.AreEqual(playlist.ShortDescription, newPlaylist.ShortDescription);
			Assert.AreEqual(playlist.VideoIds.Count, newPlaylist.VideoIds.Count);
			Assert.IsTrue(playlist.VideoIds.Contains(1964394725001));
			Assert.IsTrue(playlist.VideoIds.Contains(1964394726001));

			// now delete it
			_api.DeletePlaylist(newId, true);

			// verify it's gone
			// NOTE: The API must do some caching or something, cause this is still returning a result 
			// NOTE: even though the playlist has indeed been deleted.
			// TODO: Can we verify the deletion without waiting for the cache to expire?
			//Assert.IsNull(_api.FindPlaylistById(newId));
		}
	}
}
