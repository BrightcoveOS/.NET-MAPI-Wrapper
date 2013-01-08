using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackWrite
{
	[TestFixture]
	public class CreateAudioTrackTests : AudioTrackWriteTestBase
	{
		/// <summary>
		/// Test audio track is from ccMixter, a community remix site created by Creative Commons:  http://ccmixter.org/files/rslane32/12510
		/// </summary>
		private const string SaxString = "..\\..\\Assets\\rslane32_-_SAX_STRING.mp3";
		/// <summary>
		/// Test audio track is from archive.org. It is licensed under the Creative Commons Public Domain license. http://archive.org/details/FDR_Declares_War_19411208
		/// </summary>
		private const string FDRPearlHarborSpeech = "..\\..\\Assets\\FDR_Declares_War_19411208.mp3";
		/// <summary>
		/// Test audio track is from archive.org. It is licensed under the Creative Commons Public Domain license. http://archive.org/details/GWBush_Oval_Office_Address_20010911
		/// </summary>
		private const string GWB911Speech = "..\\..\\Assets\\GWBush_Oval_Office_Address_20010911.mp3";
		/// <summary>
		/// Test audio track is from archive.org. It is licensed under the Creative Commons Public Domain license. http://archive.org/details/jfks19630626
		/// </summary>
		private const string JFKIchBinEinBerlinerSpeech = "..\\..\\Assets\\jfk_1963_0626_berliner_64kb.mp3";

		[Test]
		public void CreateAudioTrack_Test_Basic()
		{
			long newId = Api.CreateAudioTrack(Sample0, SaxString);
			Assert.Greater(newId, 0);
		}

		[Test]
		public void CreateAudioTrack_Test_Basic_FDRSpeech()
		{
			long newId = Api.CreateAudioTrack(Sample1, FDRPearlHarborSpeech);
			Assert.Greater(newId, 0);
		}

		[Test]
		public void CreateAudioTrack_Test_Basic_GWBSpeech()
		{
			long newId = Api.CreateAudioTrack(Sample2, GWB911Speech);
			Assert.Greater(newId, 0);
		}

		[Test]
		public void CreateAudioTrack_Test_Basic_JFKSpeech()
		{
			long newId = Api.CreateAudioTrack(Sample3, JFKIchBinEinBerlinerSpeech);
			Assert.Greater(newId, 0);
		}
	}
}
