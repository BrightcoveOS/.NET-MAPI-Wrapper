using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{
	[TestFixture]
	public class FindAudioTrackByIdTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindAudioTrackById_Test_Basic()
		{
			// Rather than hardcoding an id, dynamically fetch the first id
			// of the video on the first page of the FindAllAudioTracks result.
			BrightcoveAudioTrack controlAudioTrack = _api.FindAllAudioTracks(1, 0).First();
			BrightcoveAudioTrack audioTrack = _api.FindAudioTrackById(controlAudioTrack.Id);

			Assert.IsNotNull(audioTrack);
			Assert.AreEqual(controlAudioTrack.Id, audioTrack.Id);
			Assert.AreEqual(controlAudioTrack.Name, audioTrack.Name);
			Assert.AreEqual(controlAudioTrack.ShortDescription, audioTrack.ShortDescription);
		}
	}
}
