using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Util.Extensions;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Items
{
	/// <summary>
	/// The BrightcoveAudioTrack object represents a single audio track.
	/// </summary>
	public class BrightcoveAudioTrack : BrightcoveItem, IJavaScriptConvertable
	{
		#region Properties

		/// <summary>
		/// A number, assigned by Brightcove, that uniquely identifies the account to which the Audio belongs.
		/// </summary>
		public long AccountId
		{
			get;
			private set;
		}

		/// <summary>
		/// Album title
		/// </summary>
		public string AlbumTitle
		{
			get;
			set;
		}

		/// <summary>
		/// Artist Name
		/// </summary>
		public string ArtistName
		{
			get; 
			set;
		}

		/// <summary>
		/// The date this audio track was created.
		/// </summary>
		public DateTime CreationDate
		{
			get;
			private set;
		}

		/// <summary>
		/// End date
		/// </summary>
		public DateTime EndDate
		{
			get;
			set;
		}

		/// <summary>
		/// A number that uniquely identifies this audio track, assigned by Brightcove when the track is created.
		/// </summary>
		public long Id
		{
			get;
			private set;
		}

		/// <summary>
		/// Large image URL
		/// </summary>
		public string LargeImageUrl
		{
			get;
			private set;
		}

		/// <summary>
		/// Last modified dat
		/// </summary>
		public DateTime LastModifiedDate
		{
			get; 
			private set;
		}

		/// <summary>
		/// Length
		/// </summary>
		public long Length
		{
			get;
			private set;
		}

		/// <summary>
		/// Link text
		/// </summary>
		public string LinkText
		{

			get;
			set;
		}
        
		/// <summary>
		/// Link URL
		/// </summary>
		public string LinkUrl
		{
			get;
			set;
		}

		/// <summary>
		/// A longer description of this audio track, limited to 5000 characters.
		/// </summary>
		public string LongDescription
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the audio track
		/// </summary>
		public string Name
		{ 
			get;
			set;
		}

		/// <summary>
		/// Published dat
		/// </summary>
		public DateTime PublishedDate
		{
			get; 
			private set;
		}

		/// <summary>
		/// A user-specified id that uniquely identifies the audio track, limited to 150 characters. 
		/// A referenceId can be used as a foreign-key to identify this audio track in another system. 
		/// Note that that the find_audiotracks_by_reference_ids method cannot handle a referenceId 
		/// that contain commas, so you may want to avoid using commas in referenceId values.
		/// </summary>
		public string ReferenceId
		{
			get;
			set;
		}

		/// <summary>
		/// Release date
		/// </summary>
		public DateTime ReleaseDate
		{
			get;
			set;
		}

		/// <summary>
		/// A short description describing the audio track, limited to 250 characters. The 
		/// shortDescription is a required property when you create a audio track.
		/// </summary>
		public string ShortDescription
		{
			get;
			set;
		}
               
		/// <summary>
		/// Start date
		/// </summary>
		public DateTime StartDate
		{
			get; 
			set;
		}

		/// <summary>
		/// Tags
		/// </summary>
		public ICollection<string> Tags
		{
			get; 
			private set;
		}

		/// <summary>
		/// Thumbnail URL
		/// </summary>
		public string ThumbnailUrl
		{
			get; 
			private set;
		} 

		/// <summary>
		/// Track asset URL
		/// </summary>
		public string TrackAssetUrl
		{
			get; 
			private set;
		}

		#endregion

		public BrightcoveAudioTrack ()
		{
			Tags = new List<string>();
		}

		#region IJavaScriptConvertable implementation

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

					case "albumTitle":
						AlbumTitle = (string)dictionary[key];
						break;

					case "artistName":
						ArtistName = (string)dictionary[key];
						break;

					case "creationDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => CreationDate = d);
						break;

					case "endDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => EndDate = d);
						break;

					case "id":
						Id = Convert.ToInt64(dictionary[key]);
						break;

					case "largeImageURL":
						LargeImageUrl = (string)dictionary[key];
						break;

					case "lastModifiedDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => LastModifiedDate = d);
						break;

					case "length":
						Length = Convert.ToInt64(dictionary[key]);
						break;

					case "linkText":
						LinkText = (string)dictionary[key];
						break;

					case "linkURL":
						LinkUrl = (string)dictionary[key];
						break;

					case "longDescription":
						LongDescription = (string)dictionary[key];
						break;

					case "name":
						Name = (string)dictionary[key];
						break;

					case "publishedDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => PublishedDate = d);
						break;

					case "referenceId":
						ReferenceId = (string)dictionary[key];
						break;

					case "releaseDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => ReleaseDate = d);
						break;

					case "shortDescription":
						ShortDescription = (string)dictionary[key];
						break;

					case "startDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => StartDate = d);
						break;

					case "tags":
						Tags.Clear();
						Tags.AddRange(serializer.ConvertToType<List<string>>(dictionary[key]));
						break;

					case "thumbnailURL":
						ThumbnailUrl = (string)dictionary[key];
						break;

					case "trackAssetURL":
						TrackAssetUrl = (string)dictionary[key];
						break;
				}
			}
		}

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			//Add each entry to the dictionary.
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("name", Name);
			dictionary.Add("referenceId", ReferenceId);
			dictionary.Add("shortDescription", ShortDescription);
			dictionary.Add("longDescription", LongDescription);

			return dictionary;
		}

		#endregion
	}
}
