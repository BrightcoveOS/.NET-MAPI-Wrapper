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

		// From http://stackoverflow.com/questions/1122483/c-random-string-generator
		protected readonly Random _random = new Random((int)DateTime.Now.Ticks);
		protected string RandomString(int size)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < size; i++)
			{
				char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65)));
				builder.Append(ch);
			}

			return builder.ToString();
		}
	}
}
