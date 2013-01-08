using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistRead
{
	[TestFixture]
	public class FindPlaylistsByReferenceIdsTests : PlaylistReadTestBase
	{
		[Test]
		public void FindPlaylistsByRefereceIds_Test_Basic()
		{
			_playlists = _api.FindPlaylistsByReferenceIds(new[] { "1963943648001", "1963943652001" });

			Assert.AreEqual(2, _playlists.Count);
			Assert.AreEqual(0, _playlists.Where(o => o == null).Count());
		}
	}
}
