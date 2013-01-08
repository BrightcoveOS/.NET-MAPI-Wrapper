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
	public class FindAudioTrackPlaylistsByReferenceIds : AudioTrackPlaylistReadTestBase
	{
		[Test]
		public void FindAudioTrackPlaylistsByReferenceIds_Basic_Test()
		{
			BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> playlists = _api.FindAudioTrackPlaylistsByReferenceIds(new[] { _refId, _refId2 });

			Assert.NotNull(playlists);
			Assert.AreEqual(2, playlists.Count);
			Assert.AreEqual(1, playlists.Count(o => o != null)); // only _refId is a real reference Id in the system
		}
	}
}
