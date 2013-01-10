using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{
	[TestFixture]
	public class FindAudioTrackByReferenceIdTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindAudioTrackByRefId_Test_Basic()
		{
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackByReferenceId(Sample1.ReferenceId);

			Assert.IsNotNull(audioTrack);
			
			Assert.AreEqual(Sample1.Name, audioTrack.Name);
			Assert.AreEqual(Sample1.ShortDescription, audioTrack.ShortDescription);
		}

		[Test]
		public void FindAudioTrackByRefId2_Test_Basic()
		{
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackByReferenceId(Sample2.ReferenceId);

			Assert.IsNotNull(audioTrack);
			Assert.AreEqual(Sample2.Name, audioTrack.Name);
			Assert.AreEqual(Sample2.ShortDescription, audioTrack.ShortDescription);
			Assert.AreEqual(Sample2.LongDescription, audioTrack.LongDescription);
		}

		[Test]
		public void FindAudioTrackByRefId_Test_NonExistent()
		{
			const string refId = "doesn't exist!";
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackByReferenceId(refId);

			Assert.IsNull(audioTrack);
		}

		[Test]
		public void FindAudioTrackByRefId_Test_Fields()
		{
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackByReferenceId(Sample2.ReferenceId, new List<string> { "id", "name", "shortDescription" });

			//the 3 fields we specified should be present
			Assert.IsNotNull(audioTrack);
			
			Assert.AreEqual(Sample2.Name, audioTrack.Name);
			Assert.AreEqual(Sample2.ShortDescription, audioTrack.ShortDescription);

			//other fields should not
			Assert.IsNullOrEmpty(audioTrack.LongDescription);
			Assert.IsNullOrEmpty(audioTrack.LinkUrl);
		}

		[Test]
		public void FindAudioTrackByRefId_Test_MediaDelivery()
		{
			_api.Configuration.MediaDelivery = "http";
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackByReferenceId(Sample2.ReferenceId);

			Assert.IsNotNull(audioTrack);
			Assert.IsTrue(audioTrack.TrackAssetUrl.StartsWith("http://"));
		}

		[Test]
		public void FindAudioTrackByRefId_Test_DefaultMediaDelivery()
		{
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackByReferenceId(Sample2.ReferenceId);

			Assert.IsNotNull(audioTrack);
			Assert.IsTrue(audioTrack.TrackAssetUrl.StartsWith("rtmp://"));
		}

	}
}
