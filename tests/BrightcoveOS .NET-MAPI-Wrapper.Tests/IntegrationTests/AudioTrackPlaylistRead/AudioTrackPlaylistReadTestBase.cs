using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistRead
{
	public abstract class AudioTrackPlaylistReadTestBase
	{
		protected BrightcoveApi _api;
		protected BrightcoveItemCollection<BrightcoveAudioTrackPlaylist> _playlists;
		protected const string _refId = "test-audio-playlist-reference-id";
		protected string _refId2 = "test-audio-playlist-reference-id2";
		// Currently the only active audio track playlist in the system.
		protected const long playlistId = 2064604653001;

		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.ReadToken);
		}
	}
}
