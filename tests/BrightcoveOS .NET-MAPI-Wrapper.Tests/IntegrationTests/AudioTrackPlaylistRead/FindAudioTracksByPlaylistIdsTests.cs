using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistRead
{
	[TestFixture]
	public class FindAudioTracksByPlaylistIdsTests : AudioTrackPlaylistReadTestBase
	{
		[Test]
		public void FindAudioTracksByPlaylistIds_Basic_Test()
		{
			BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> playlists = _api.FindAudioTrackPlaylistsByIds(new[] { playlistId, long.MaxValue });

			Assert.NotNull(playlists);
			Assert.AreEqual(2, playlists.Count);
			Assert.AreEqual(1, playlists.Count(o => o != null)); // only one playlist is in the system
		}
	}
}
