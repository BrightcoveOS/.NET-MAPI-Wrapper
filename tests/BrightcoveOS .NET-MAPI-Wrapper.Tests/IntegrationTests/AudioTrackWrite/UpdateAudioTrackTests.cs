using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackWrite
{
	[TestFixture]
	public class UpdateAudioTrackTests : AudioTrackWriteTestBase
	{
		[Test]
		public void UpdateAudioTrackInformation_Test_Basic()
		{
			BrightcoveAudioTrack audioTrack = new BrightcoveAudioTrack();
			audioTrack.ReferenceId = AudioTrack.ReferenceId;
			audioTrack.ShortDescription = RandomString(20);
			audioTrack.LongDescription = RandomString(200);
			audioTrack.Name = "Gabe Test 467";

			BrightcoveAudioTrack result = Api.UpdateAudioTrack(audioTrack);

			Assert.AreEqual(audioTrack.ShortDescription, result.ShortDescription);
			Assert.AreEqual(audioTrack.LongDescription, result.LongDescription);
			Assert.AreEqual(audioTrack.Name, result.Name);
		}

		[Test]
		public void UpdateAudioTrackInformation_Tags_Test()
		{
			BrightcoveItemCollection<BrightcoveAudioTrack> audioTracks = Api.FindAllAudioTracks();

			BrightcoveAudioTrack audioTrack = audioTracks.Single(x => x.LongDescription.Contains("arbor")); // arbor for pearl hARBOR
			// Make sure the tag property changes.
			string[] tags = audioTrack.Tags.Any() ? new string[] { } : new[] { "War", "world-war-two", "Japan", "president" };
			audioTrack.Tags = tags;
			BrightcoveAudioTrack result = Api.UpdateAudioTrack(audioTrack);

			Assert.IsTrue(tags.OrderBy(x => x).SequenceEqual(result.Tags.OrderBy(x => x)));
		}
	}
}
