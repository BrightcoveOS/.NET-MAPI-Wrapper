using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistRead
{
	public abstract class PlaylistReadTestBase
	{
		protected BrightcoveApi _api;
		protected BrightcoveItemCollection<BrightcovePlaylist> _playlists;

		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.ReadToken);
		}

	}
}
