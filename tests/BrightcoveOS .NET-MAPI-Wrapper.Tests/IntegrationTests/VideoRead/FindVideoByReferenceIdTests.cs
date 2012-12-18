using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindVideoByReferenceIdTests
	{
		private string _refId = "1939643268001";
		private BrightcoveApi _api;

		[SetUp]
		public void SetUp()
		{
			// Reset to default configuration
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.VideoReadKey);
		}

		[Test]
		public void FindVideoByRefId_Basic()
		{
			BrightcoveVideo video = _api.FindVideoByReferenceId(_refId);

			Assert.IsNotNull(video);
			Assert.AreEqual(1939643268001, video.Id);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.Name);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.ShortDescription);
		}

		[Test]
		public void FindVideoByRefId_Renditions()
		{
			BrightcoveVideo video = _api.FindVideoByReferenceId(_refId);

			Assert.Greater(video.Renditions.Count, 0);
		}

		[Test]
		public void FindVideoByRefId_NonExistent()
		{
			string refId = "doesn't exist!";
			BrightcoveVideo video = _api.FindVideoByReferenceId(refId);

			Assert.IsNull(video);
		}
	}
}
