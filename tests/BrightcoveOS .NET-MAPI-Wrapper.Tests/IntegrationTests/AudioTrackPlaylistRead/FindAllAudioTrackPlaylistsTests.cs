using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistRead
{
	[TestFixture]
	public class FindAllAudioTrackPlaylistsTests : AudioTrackPlaylistReadTestBase
	{
		[Test]
		public void FindAllAudioTrackPlaylists_Basic_Test()
		{
			_playlists = _api.FindAllAudioTrackPlaylists(1, 0);
			Assert.NotNull(_playlists);

			Assert.Greater(_playlists.Count, 0);
		}
	}
}
