using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistRead
{
	[TestFixture]
	public class FindPlaylistsForPlayerIdTests : PlaylistReadTestBase
	{
		[Test]
		public void FindPlaylistsForPlayerId_Test_Basic()
		{
			_playlists = _api.FindPlaylistsForPlayerId(1964524200001);

			Assert.Greater(_playlists.Count, 0);
			Assert.AreEqual(0, _playlists.Where(o => o == null).Count());
		}
	}
}
