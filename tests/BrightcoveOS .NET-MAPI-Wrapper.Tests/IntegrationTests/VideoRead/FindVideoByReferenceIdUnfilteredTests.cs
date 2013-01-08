using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoRead
{
	[TestFixture]
	public class FindVideoByReferenceIdUnfilteredTests : VideoReadTestBase
	{
		private string _refId = "1939643268001";

		/// <summary>
		/// Will throw an exception as the test token does not have unfiltered access.
		/// </summary>
		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void FindVideoByRefIdUnfiltered_Basic()
		{
			BrightcoveVideo video = _api.FindVideoByReferenceIdUnfiltered(_refId);

			Assert.IsNotNull(video);
			Assert.AreEqual(1939643268001, video.Id);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.Name);
			Assert.AreEqual("Wildlife_TamarinMonkey", video.ShortDescription);
		}

		/// <summary>
		/// Will throw an exception as the test token does not have unfiltered access.
		/// </summary>
		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void FindVideoByRefIdUnfiltered_NonExistent()
		{
			string refId = "doesn't exist!";
			BrightcoveVideo video = _api.FindVideoByReferenceIdUnfiltered(refId);

			Assert.IsNull(video);
		}
	}
}
