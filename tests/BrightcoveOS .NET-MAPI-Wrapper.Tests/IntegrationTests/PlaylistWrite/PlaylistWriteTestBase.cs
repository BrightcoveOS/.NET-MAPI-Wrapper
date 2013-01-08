using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.PlaylistWrite
{
	public abstract class PlaylistWriteTestBase
	{
		protected BrightcoveApi _api;

		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.ReadToken, ApiKeys.WriteToken);
		}
	}
}
