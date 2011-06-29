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
	/// The BrightcovePlaylist object is a collection of BrightcoveVideos.
	/// </summary>
	public class BrightcovePlaylist : BrightcoveItem, IJavaScriptConvertable
	{
		#region Properties


		/// <summary>
		/// A number that uniquely identifies the account to which this Playlist belongs, assigned by Brightcove.
		/// </summary>
		public long AccountId
		{
			get;
			private set;
		}

		/// <summary>
		/// A list of the tags that apply to this smart playlist.
		/// </summary>
		public ICollection<string> FilterTags
		{
			get;
			private set;
		}


		/// <summary>
		/// A number that uniquely identifies the Playlist. This id is automatically assigned when 
		/// the Playlist is created.
		/// </summary>
		public long Id
		{
			get;
			private set;
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
		/// Note that the find_playlists_by_reference_ids method cannot handle referenceIds that 
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
		/// For a smart playlist, defines whether the video must contain all or contain 
		/// one or more of the values in filterTags. Use AND for "contains all" and OR for 
		/// "contains one or more." Not available in Read API methods.
		/// </summary>
		public TagInclusionRule TagInclusionRule
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
			private set;
		}

		/// <summary>
		/// A list of the ids of the Videos that are encapsulated in the Playlist.
		/// </summary>
		public ICollection<long> VideoIds
		{
			get;
			private set;
		}

		/// <summary>
		/// A list of the BrightcoveVideo objects that are encapsulated in the Playlist.
		/// </summary>
		public ICollection<BrightcoveVideo> Videos
		{
			get;
			private set;
		}

		#endregion

		public BrightcovePlaylist()
		{
			FilterTags = new List<string>();
			VideoIds = new List<long>();
			Videos = new List<BrightcoveVideo>();
			PlaylistType = PlaylistType.Explicit;
			TagInclusionRule = TagInclusionRule.And;
		}

		#region Implementation of IJavaScriptConvertable

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			IDictionary<string, object> serialized = new Dictionary<string, object>();

			serialized["filterTags"] = FilterTags;
			serialized["id"] = Id;
			serialized["name"] = Name;
			serialized["playlistType"] = PlaylistType.ToBrightcoveName();
			serialized["referenceId"] = ReferenceId;
			serialized["shortDescription"] = ShortDescription;
			serialized["tagInclusionRule"] = TagInclusionRule.ToBrightcoveName();
			serialized["thumbnailURL"] = ThumbnailUrl;
			serialized["videoIds"] = VideoIds;
			serialized["videos"] = Videos;
			
			return serialized;
		}

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

					case "tagInclusionRule":
						TagInclusionRule = ((string)dictionary[key]).ToBrightcoveEnum<TagInclusionRule>();
						break;

					case "thumbnailURL":
						ThumbnailUrl = (string)dictionary[key];
						break;

					case "videos":
						Videos = serializer.ConvertToType<List<BrightcoveVideo>>(dictionary[key]);
						break;

					case "videoIds":
						VideoIds = serializer.ConvertToType<List<long>>(dictionary[key]);
						break;
				}
			}
		}

		#endregion
	}
}
