using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistRead
{
	[TestFixture]
	public class FindPlaylistByReferenceIdTests : PlaylistReadTestBase
	{
		[Test]
		public void FindPlaylistByRefereceId_Test_Basic()
		{
			BrightcovePlaylist playlist = _api.FindPlaylistByReferenceId("1963943648001");

			Assert.NotNull(playlist);
			Assert.Greater(playlist.VideoIds.Count, 0);
			Assert.Greater(playlist.Videos.Count, 0);
		}
	}
}
