using System;
using System.IO;
using System.Linq;
using BrightcoveMapiWrapper.Api.Connectors;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
    [TestFixture]
    public class AddCaptioningTest : VideoWriteTestBase
    {
        //Sample DFXP Files
        private readonly string FileToUpload = @"..\\..\\Assets\\Sample_CaptionFile.dfxp";
        private readonly string ExternalCaptionUrl = "https://raw.githubusercontent.com/BrightcoveOS/.NET-MAPI-Wrapper/master/tests/BrightcoveOS%20.NET-MAPI-Wrapper.Tests/Assets/Sample_CaptionFile.dfxp";

        [Test]
        public void AddCaptioning_ExternalUrl_VideoId()
        {
            var filename = "Caption Test";
            var result = _api.AddCaptioning(ExternalCaptionUrl, 4348957026001, filename);

            Assert.That(result != null);
            Assert.That(result.Id > 0);
            Assert.That(result.CaptionSources.Count == 1);

            var captionSource = result.CaptionSources.First();
            Assert.IsTrue(captionSource.IsRemote);
            Assert.IsTrue(captionSource.Complete);
            Assert.AreEqual(captionSource.Url, ExternalCaptionUrl);
            Assert.AreEqual(captionSource.DisplayName, filename);
        }

        [Test]
        public void AddCaptioning_FileUploadInfo_VideoId()
        {
            using (var fs = File.OpenRead(FileToUpload))
            {
                var filename = "Test Caption";
                var captionFileUploadInfo = new FileUploadInfo(fs, filename);
                var result = _api.AddCaptioning(captionFileUploadInfo, 4348957026001, filename);

                Assert.That(result != null);
                Assert.That(result.Id > 0);
                Assert.That(result.CaptionSources.Count == 1);

                var captionSource = result.CaptionSources.First();
                Assert.IsFalse(captionSource.IsRemote);
                Assert.That(String.IsNullOrEmpty(captionSource.Url));
                Assert.AreEqual(captionSource.DisplayName, filename);
            }
        }
    }
}