using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistWrite
{
	public abstract class AudioTrackPlaylistWriteTestBase
	{
		protected BrightcoveApi _api;
		protected const string _refId = "test-audio-playlist-reference-id";

		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.ReadToken, ApiKeys.WriteToken);
		}
	}
}
