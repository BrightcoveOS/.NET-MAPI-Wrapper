using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistRead
{
	[TestFixture]
	public class FindAllPlaylistsTests : PlaylistReadTestBase
	{
		[Test]
		public void FindAllPlaylists_Test_Basic()
		{
			_playlists = _api.FindAllPlaylists();

			Assert.Greater(_playlists.Count, 0);
			Assert.Greater(_playlists[0].VideoIds.Count, 0);
			Assert.Greater(_playlists[0].Videos.Count, 0);
		}
	}
}
