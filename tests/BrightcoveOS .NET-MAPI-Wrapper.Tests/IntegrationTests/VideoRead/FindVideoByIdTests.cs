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
	public class FindVideoByIdTests : VideoReadTestBase
	{
		private long _id = 1939643268001;

		[Test]
		public void FindVideoById_Basic()
		{
			BrightcoveVideo video = _api.FindVideoById(_id);

			Assert.IsNotNull(video);
			Assert.AreEqual(_id, video.Id);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.Name);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.ShortDescription);
		}
	}
}
