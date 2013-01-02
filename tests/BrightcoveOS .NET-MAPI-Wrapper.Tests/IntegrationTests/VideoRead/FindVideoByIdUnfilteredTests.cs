using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Items;
using BrightcoveMapiWrapper.Api;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindVideoByIdUnfilteredTests : VideoReadTestBase
	{
		private long _id = 1939643268001;

		/// <summary>
		/// Will throw an exception as the test token does not have unfiltered access.
		/// </summary>
		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void FindVideoByIdUnfiltered_Basic()
		{
			BrightcoveVideo video = _api.FindVideoByIdUnfiltered(_id);

			Assert.IsNotNull(video);
			Assert.AreEqual(_id, video.Id);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.Name);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.ShortDescription);
		}
	}
}
