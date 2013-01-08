using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Items
{
	/// <summary>
	/// The BrightcoveAudioTrackPlaylist object is a collection of BrightcoveAudioTracks.
	/// </summary>
	public class BrightcoveAudioTrackPlaylist : BrightcoveItem, IJavaScriptConvertable
	{
		/// <summary>
		/// The ID of the account to which this Playlist belongs, assigned by Brightcove.
		/// </summary>
		public long AccountId
		{
			get;
			private set;
		}

		/// <summary>
		/// A list of IDs of the audio tracks contained in this playlist
		/// </summary>
		public ICollection<long> AudioTrackIds
		{
			get;
			set;
		}

		/// <summary>
		/// A list of BrightcoveAudioTracks contained in this playlist
		/// </summary>
		public ICollection<BrightcoveAudioTrack> AudioTracks
		{
			get;
			set;
		}

		/// <summary>
		/// A list of the tags that apply to this smart playlist.
		/// </summary>
		public ICollection<string> FilterTags
		{
			get;
			set;
		}

		/// <summary>
		/// A number that uniquely identifies the Playlist. This id is automatically assigned when 
		/// the Playlist is created.
		/// </summary>
		public long Id
		{
			get;
			set;
		}

		/// <summary>
		/// The title of this Playlist, limited to 100 characters. The name is a required property when you
		/// create a playlist.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// For a manual playlist, set this to EXPLICIT. For a smart playlist, indicate how to order the playlist by setting this to one of the following choices: 
		/// OLDEST_TO_NEWEST (by activated date)
		/// NEWEST_TO_OLDEST (by activated date)
		/// START_DATE_OLDEST_TO_NEWEST
		/// START_DATE_NEWEST_TO_OLDEST 
		/// ALPHABETICAL (by video name)
		/// PLAYSTOTAL
		/// PLAYS_TRAILING_WEEK
		/// 
		/// The playlistType is a required property when you create a playlist.
		/// </summary>
		public PlaylistType PlaylistType
		{
			get;
			set;
		}

		/// <summary>
		/// A user-specified id, limited to 150 characters, that uniquely identifies this Playlist. 
		/// Note that the find_audiotrack_playlists_by_ids method cannot handle referenceIds that 
		/// contain commas, so you may want to avoid using commas in referenceId values.
		/// </summary>
		public string ReferenceId
		{
			get;
			set;
		}

		/// <summary>
		/// A short description describing the Playlist, limited to 250 characters.
		/// </summary>
		public string ShortDescription
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of the thumbnail associated with this Playlist.
		/// </summary>
		public string ThumbnailUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public BrightcoveAudioTrackPlaylist()
		{
			AudioTrackIds = new List<long>();
			AudioTracks = new List<BrightcoveAudioTrack>();
			FilterTags = new List<string>();
			PlaylistType = PlaylistType.Explicit;
		}

		#region Implementation of IJavaScriptConvertable

		/// <summary>
		/// Serializes the <see cref="BrightcoveAudioTrackPlaylist"/>. Note that the <see cref="AudioTracks"/> property is not serialized with the rest of the other properties as the <see cref="AudioTrackIds"/> properties is instead used by Brightcove.
		/// </summary>
		/// <param name="serializer">The serializer.</param>
		/// <returns>
		/// A serialized <see cref="IDictionary{String,Object}" />.
		/// </returns>
		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			IDictionary<string, object> serialized = new Dictionary<string, object>();
			
			serialized["filterTags"] = FilterTags;
			serialized["name"] = Name;
			serialized["playlistType"] = PlaylistType.ToBrightcoveName();
			serialized["referenceId"] = ReferenceId;
			serialized["shortDescription"] = ShortDescription;
			serialized["thumbnailURL"] = ThumbnailUrl;

			// The Id must be non-0.
			if (Id != 0)
			{
				serialized["id"] = Id;
			}

			// Smart playlists (i.e. anything but an Explicit playlist) should not have the VideoIds
			// populated, as 1) Brightcove determines which video Ids belong in a smart playlist, and
			// 2) serializing this property for a smart playlists results in an error.
			//
			// It is still the case that you cannot switch from a smart playlist to an explicit playlist,
			// and attempting to do so will result in an error. A workaround in this case is detailed @
			// https://github.com/BrightcoveOS/.NET-MAPI-Wrapper/wiki/Known-Issues#wiki-convert-smart-playlist-to-explicit.
			if (PlaylistType == PlaylistType.Explicit && AudioTrackIds != null && AudioTrackIds.Any())
			{
				serialized["audioTrackIds"] = AudioTrackIds;
			}

			return serialized;
		}

		/// <summary>
		/// Deserializes the specified dictionary.
		/// </summary>
		/// <param name="dictionary">The <see cref="IDictionary{String,Object}" />.</param>
		/// <param name="serializer">The <see cref="JavaScriptSerializer" />.</param>
		public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
		{
			foreach (string key in dictionary.Keys)
			{
				switch (key)
				{
					case "error":
						ApiUtil.ThrowIfError(dictionary, key, serializer);
						break;

					case "accountId":
						AccountId = Convert.ToInt64(dictionary[key]);
						break;

					case "audioTracks":
						AudioTracks = serializer.ConvertToType<List<BrightcoveAudioTrack>>(dictionary[key]);
						break;

					case "audioTrackIds":
						AudioTrackIds = serializer.ConvertToType<List<long>>(dictionary[key]);
						break;

					case "filterTags":
						FilterTags = serializer.ConvertToType<List<string>>(dictionary[key]);
						break;

					case "id":
						Id = Convert.ToInt64(dictionary[key]);
						break;

					case "name":
						Name = (string)dictionary[key];
						break;

					case "playlistType":
						PlaylistType = ((string)dictionary[key]).ToBrightcoveEnum<PlaylistType>();
						break;

					case "referenceId":
						ReferenceId = (string)dictionary[key];
						break;

					case "shortDescription":
						ShortDescription = (string)dictionary[key];
						break;

					case "thumbnailURL":
						ThumbnailUrl = (string)dictionary[key];
						break;
				}
			}
		}

		#endregion
	}
}
