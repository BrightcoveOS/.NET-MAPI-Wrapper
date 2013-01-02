using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackWrite
{
	[TestFixture]
	public class AddAudioImageTests : AudioTrackWriteTestBase
	{
		/// <summary>
		/// Test image.
		/// </summary>
		private const string TestImage = "..\\..\\Assets\\test-image.png";

		[Test]
		public void AddImage_Test_Basic()
		{
			BrightcoveImage image = new BrightcoveImage
			{
				Type = ImageType.Thumbnail
			};

			Api.AddAudioImage(image, TestImage, AudioTrack.Id);

			// TODO: not sure how to verify this worked other than the lack of error
		}

		[Test]
		public void AddImage_Test_VideoRefId()
		{
			BrightcoveImage image = new BrightcoveImage
			{
				Type = ImageType.Thumbnail
			};

			Api.AddAudioImage(image, TestImage, AudioTrack.ReferenceId);

			// TODO: not sure how to verify this worked other than the lack of error
		}
	}
}
