using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Items;
using BrightcoveMapiWrapper.Model.Containers;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackWrite
{
	[TestFixture]
	public class DeleteAudioTrackTests : AudioTrackWriteTestBase
	{
		/// <summary>
		/// Deletes all the audio tracks in the account.
		/// </summary>
		[Test]
		public void DeleteAudioTrackByIdTest()
		{
			BrightcoveItemCollection<BrightcoveAudioTrack> audioTracks = Api.FindAllAudioTracks();

			foreach (BrightcoveAudioTrack audioTrack in audioTracks)
			{
				Api.DeleteAudioTrack(audioTrack.Id, true, true);
			}
		}
	}
}
