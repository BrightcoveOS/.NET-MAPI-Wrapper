using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackRead
{	
	[TestFixture]
	public class FindAllAudioTracksTests : AudioTrackReadTestBase
	{
		[Test]
		public void FindAllAudioTracks_Test_Basic()
		{
			_audioTracks = _api.FindAllAudioTracks();

			// Since we're testing against a test account that has a variable amount of audio tracks, we can only test that the collection is not null.
			Assert.That(_audioTracks != null && _audioTracks.Any());
		}

		[Test]
		public void FindAllAudioTracks_Test_PageSize()
		{
			_audioTracks = _api.FindAllAudioTracks(1, 0);

			// Let's assume that there are some existing audio tracks already populated. If not, run some of the create tests.
			Assert.AreEqual(1, _audioTracks.Count);
			Assert.AreEqual(1, _audioTracks.PageSize);
		}

		[Test]
		public void FindAllAudioTracks_Test_PageNum()
		{
			_audioTracks = _api.FindAllAudioTracks(1, 1, SortBy.CreationDate);

			Assert.Less(0, _audioTracks.PageNumber);
		}

		[Test]
		public void FindAllAudioTracks_Test_Sort()
		{
			_audioTracks = _api.FindAllAudioTracks(10, 0, SortBy.CreationDate);
			Assert.GreaterOrEqual(10, _audioTracks.Count);

			//verify each video's creation date is in order
			BrightcoveAudioTrack lastAudioTrack = null;
			foreach (BrightcoveAudioTrack bcAudioTrack in _audioTracks)
			{
				if (lastAudioTrack == null)
				{
					lastAudioTrack = bcAudioTrack;
					continue;
				}
				Assert.LessOrEqual(lastAudioTrack.CreationDate, bcAudioTrack.CreationDate);
				lastAudioTrack = bcAudioTrack;
			}
		}

		[Test]
		public void FindAllAudioTracks_Test_SortOrder()
		{
			_audioTracks = _api.FindAllAudioTracks(10, 0, SortBy.CreationDate, SortOrder.Descending);
			Assert.GreaterOrEqual(10, _audioTracks.Count);

			//verify each video's creation date is in order
			BrightcoveAudioTrack lastAudioTrack = null;
			foreach (BrightcoveAudioTrack bcAudioTrack in _audioTracks)
			{
				if (lastAudioTrack == null)
				{
					lastAudioTrack = bcAudioTrack;
					continue;
				}
				Assert.GreaterOrEqual(lastAudioTrack.CreationDate, bcAudioTrack.CreationDate);
				lastAudioTrack = bcAudioTrack;
			}
		}

		[Test]
		public void FindAllAudioTracks_Test_Fields()
		{
			_audioTracks = _api.FindAllAudioTracks(1, 0, SortBy.CreationDate, SortOrder.Descending, new List<string> { "id", "name", "shortDescription" });
			Assert.AreEqual(1, _audioTracks.Count);
			BrightcoveAudioTrack audioTrack = _audioTracks.FirstOrDefault();

			if (audioTrack != null)
			{
				//the 3 fields we specified should be present
				Assert.Greater(audioTrack.Id, 0);
				Assert.IsNotNullOrEmpty(audioTrack.Name);
				Assert.IsNotNullOrEmpty(audioTrack.ShortDescription);

				//other fields should not
				Assert.IsNullOrEmpty(audioTrack.LongDescription);
				Assert.IsNullOrEmpty(audioTrack.LinkUrl);
			}
		}

		[Test]
		public void FindAllAudioTracks_Test_GetCount()
		{
			_audioTracks = _api.FindAllAudioTracks(1, 0); // count is retrieved by default

			// just make sure the field is getting set
			Assert.Less(1, _audioTracks.TotalCount);
		}
	}
}
