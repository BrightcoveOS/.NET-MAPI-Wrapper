using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistWrite
{
	[TestFixture]
	public class CreatePlaylistTests : PlaylistWriteTestBase
	{
		[Test]
		public void CreatePlaylist_Test_Basic()
		{
			BrightcovePlaylist playlist = new BrightcovePlaylist();
			playlist.Name = "Test Playlist";
			playlist.ShortDescription = "Test Short Description";
			playlist.VideoIds.Add(1964394725001);
			playlist.VideoIds.Add(1964394726001);
			playlist.VideoIds.Add(1964394737001);

			long newId = _api.CreatePlaylist(playlist);
			BrightcovePlaylist newPlaylist = _api.FindPlaylistById(newId);

			Assert.AreEqual(playlist.Name, newPlaylist.Name);
			Assert.AreEqual(playlist.ShortDescription, newPlaylist.ShortDescription);
			Assert.AreEqual(playlist.VideoIds.Count, newPlaylist.VideoIds.Count);
			Assert.IsTrue(playlist.VideoIds.Contains(1964394725001));
			Assert.IsTrue(playlist.VideoIds.Contains(1964394726001));
			Assert.IsTrue(playlist.VideoIds.Contains(1964394737001));
		}
	}
}
