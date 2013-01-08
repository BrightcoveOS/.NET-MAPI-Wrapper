using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Items;
using NUnit.Framework;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Api;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.AudioTrackPlaylistWrite
{
	[TestFixture]
	public class CreateAudioTrackPlaylistTests : AudioTrackPlaylistWriteTestBase
	{
		[Test]
		public void CreateAudioTrackPlaylist_Test_Basic()
		{
			BrightcoveItemCollection<BrightcoveAudioTrack> audioTracks = _api.FindAllAudioTracks(4, 0);
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-5" + RandomString(8),
				// Get a list of random audio tracks to add to the playlist.
				AudioTrackIds = audioTracks.Select(x => x.Id).ToList(),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.Explicit,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			BrightcoveAudioTrackPlaylist newPlaylist = _api.FindAudioTrackPlaylistById(newId);

			Assert.AreEqual(playlist.Name, newPlaylist.Name);
			Assert.AreEqual(playlist.ReferenceId, newPlaylist.ReferenceId);
			Assert.AreEqual(playlist.ShortDescription, newPlaylist.ShortDescription);
			Assert.AreEqual(audioTracks.Count, newPlaylist.AudioTrackIds.Count);
			Assert.AreEqual(audioTracks.Count, newPlaylist.AudioTracks.Count);
			Assert.AreEqual(audioTracks.Count, newPlaylist.AudioTracks.Count(o => o != null));
		}

		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_PlaysTotal()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-6" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.PlaysTotal,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}

		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_PlaysTrailingWeek()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-6" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.PlaysTrailingWeek,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}

		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_StartDateNewestToOldest()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-7" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.StartDateNewestToOldest,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}

		[Test]
		[ExpectedException(typeof(BrightcoveApiException))]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_StartDateOldestToNewest()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-8" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.StartDateOldestToNewest,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}

		[Test]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_Alphabetical()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-9" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.Alphabetical,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}

		[Test]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_NewestToOldest()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-10" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.NewestToOldest,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}

		[Test]
		public void CreateAudioTrackPlaylist_Test_PlaylistType_OldestToNewest()
		{
			BrightcoveAudioTrackPlaylist playlist = new BrightcoveAudioTrackPlaylist
			{
				Name = "Test Audio Playlist",
				ReferenceId = "new-reference-id-11" + RandomString(8),
				ShortDescription = "This is a playlist's short description",
				PlaylistType = PlaylistType.OldestToNewest,
				FilterTags = new[] { "president" }
			};

			long newId = _api.CreateAudioTrackPlaylist(playlist);
			Assert.Greater(newId, 0);
		}
	}
}
