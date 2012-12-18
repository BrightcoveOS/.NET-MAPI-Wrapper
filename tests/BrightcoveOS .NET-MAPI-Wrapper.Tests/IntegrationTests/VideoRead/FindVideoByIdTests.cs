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
	public class FindVideoByIdTests
	{
		private long _id = 1939643268001;
		private BrightcoveApi _api;

		[SetUp]
		public void SetUp()
		{
			// Reset to default configuration
			_api = BrightcoveApiFactory.CreateApi(ApiKeys.VideoReadKey);
		}

		[Test]
		public void FindVideoById_Basic()
		{
			BrightcoveVideo video = _api.FindVideoById(_id);

			Assert.IsNotNull(video);
			Assert.AreEqual(_id, video.Id);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.Name);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.ShortDescription);
		}

		[Test]
		public void FindVideoById_IncludeCustomField()
		{
			long id = 424758964001;
			BrightcoveVideo video = _api.FindVideoById(id, null, new[] { "date" });

			Assert.IsNotNull(video);
			Assert.AreEqual(424758964001, video.Id);
			Assert.AreEqual("Modern Treatment for Vascular Anomalies", video.Name);
			Assert.AreEqual("October 23, 2009", video.CustomFields["date"]);
		}
	}
}
