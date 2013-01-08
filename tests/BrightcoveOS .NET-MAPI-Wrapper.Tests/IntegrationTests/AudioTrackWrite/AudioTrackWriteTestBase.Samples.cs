using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model.Items;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackWrite
{
	public abstract partial class AudioTrackWriteTestBase
	{
		protected BrightcoveAudioTrack Sample0
		{
			get
			{
				return new BrightcoveAudioTrack
				{
					ReferenceId = "test-audio-reference-id",
					Name = "test-audio-reference-id",
					ShortDescription = "Test audio, created via the API.",
					LongDescription = "Test audio, created via the API. Audio is from ccMixter, a community remix site created by Creative Commons: http://ccmixter.org/files/rslane32/12510"
				};
			}
		}

		protected BrightcoveAudioTrack Sample1
		{
			get
			{
				return new BrightcoveAudioTrack
				{
					ReferenceId = "FDR-Pearl-Harbor",
					Name = "President Franklin D. Roosevelt Declares War on Japan (December 8, 1941)",
					ShortDescription = "President Franklin Delano Roosevelt asks Congress to declare war on Japan in a joint session of congress one day after the attack on Pearl Harbor.",
					LongDescription = "President Franklin Delano Roosevelt asks Congress to declare war on Japan in a joint session of congress one day after the attack on Pearl Harbor. Test audio track is from archive.org. It is licensed under the Creative Commons Public Domain license. http://archive.org/details/FDR_Declares_War_19411208",
				};
			}
		}

		protected BrightcoveAudioTrack Sample2
		{
			get
			{
				return new BrightcoveAudioTrack
				{
					ReferenceId = "GWB-911",
					Name = "George W. Bush Speaks from the Oval Office 9/11/2001 (September 11, 2001)",
					ShortDescription = "Statement by President George W. Bush in His Address to the Nation September 11, 2001.",
					LongDescription = "Statement by President George W. Bush in His Address to the Nation September 11, 2001. Test audio track is from archive.org. It is licensed under the Creative Commons Public Domain license. http://archive.org/details/GWBush_Oval_Office_Address_20010911",
				};
			}
		}

		protected BrightcoveAudioTrack Sample3
		{
			get
			{
				return new BrightcoveAudioTrack
				{
					ReferenceId = "JFK-Berlin",
					Name = "John F. Kennedy Speech, June 26, 1963 (June 26, 1963)",
					ShortDescription = "\"Ich bin ein Berliner\" speech. Berlin, Germany.",
					LongDescription = "\"Ich bin ein Berliner\" speech. Berlin, Germany. Test audio track is from archive.org. It is licensed under the Creative Commons Public Domain license. http://archive.org/details/jfks19630626",
				};
			}
		}
	}
}
