﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindVideosByIdsTests
	{
		private BrightcoveApi _api;
		private BrightcoveItemCollection<BrightcoveVideo> _videos;

		[SetUp]
		public void SetUp()
		{
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.VideoReadKey);
		}

		[Test]
		public void FindVideosByIds_Basic()
		{
			List<long> ids = new List<long>
			                   	{
			                   		1939643268001,
									1964441415001
			                   	};

			_videos = _api.FindVideosByIds(ids);

			Assert.AreEqual(2, _videos.Count);
			Assert.AreEqual(0, _videos.Where(o => o == null).Count());
		}
	}
}
