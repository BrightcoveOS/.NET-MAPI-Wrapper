using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackWrite
{
	[TestFixture]
	public class GetAudioTrackUploadStatusTests : AudioTrackWriteTestBase
	{
		[Test]
		public void GetAudioTrackUploadStatus_Test_Basic()
		{
			BrightcoveUploadStatus result = Api.GetAudioTrackUploadStatus(AudioTrack.ReferenceId);
			Assert.AreEqual(BrightcoveUploadStatus.Complete, result);
		}
	}
}
