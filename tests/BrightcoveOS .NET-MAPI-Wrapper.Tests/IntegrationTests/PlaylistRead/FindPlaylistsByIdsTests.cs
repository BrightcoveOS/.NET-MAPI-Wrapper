using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistRead
{
	[TestFixture]
	public class FindPlaylistsByIdsTests : PlaylistReadTestBase
	{
		[Test]
		public void FindPlaylistsByIds_Test_Basic()
		{
			_playlists = _api.FindPlaylistsByIds(new[] { 1963943648001, 1963943652001 });

			Assert.AreEqual(2, _playlists.Count);
			Assert.AreEqual(0, _playlists.Where(o => o == null).Count());
		}
	}
}
