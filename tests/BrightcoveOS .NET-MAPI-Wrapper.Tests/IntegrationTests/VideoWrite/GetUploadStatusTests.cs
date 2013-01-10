using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
	[TestFixture]
	public class GetUploadStatusTests : VideoWriteTestBase
	{
		[Test]
		public void GetUploadStatus_Test_Basic()
		{
			BrightcoveUploadStatus status = _api.GetUploadStatus(1942305739001);
			Assert.AreEqual(BrightcoveUploadStatus.Complete, status);
		}

		[Test]
		public void GetUploadStatus_Test_ByRefId()
		{
			BrightcoveUploadStatus status = _api.GetUploadStatus("1942305739001");
			Assert.AreEqual(BrightcoveUploadStatus.Complete, status);
		}
	}
}
