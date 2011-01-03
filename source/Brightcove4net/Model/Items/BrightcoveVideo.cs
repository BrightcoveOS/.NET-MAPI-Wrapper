using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using Brightcove4net.Model.Containers;
using Brightcove4net.Serialization;
using Brightcove4net.Util;
using Brightcove4net.Util.Extensions;

namespace Brightcove4net.Model.Items
{
	/// <summary>
	/// The BrightcoveVideo object is an aggregate of metadata and asset information associated with a video.
	/// </summary>
	public class BrightcoveVideo : BrightcoveItem, IJavaScriptConvertable
	{
		#region Properties 

		/// <summary>
		/// A number, assigned by Brightcove, that uniquely identifies the account to which the Video belongs.
		/// </summary>
		public long AccountId
		{
			get;
			private set;
		}

		/// <summary>
		/// The date this Video was created.
		/// </summary>
		public DateTime CreationDate
		{
			get;
			private set;
		}

		/// <summary>
		/// A list of the CuePoints objects assigned to this Video.
		/// </summary>
		public ICollection<BrightcoveCuePoint> CuePoints
		{
			get;
			private set;
		}

		/// <summary>
		/// A collection of custom field values
		/// </summary>
		public CustomFieldCollection CustomFields
		{
			get;
			private set;
		}

		/// <summary>
		/// Either FREE or AD_SUPPORTED. AD_SUPPORTED means that ad requests are enabled for the Video.
		/// </summary>
		public Economics Economics
		{
			get;
			set;
		}

		/// <summary>
		/// The last date this Video is available to be played.
		/// </summary>
		public DateTime EndDate
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of the video file for this Video. Note that this property can be accessed
		/// with the Media API only with a special read or write token. This property applies, 
		/// no matter whether the video's encoding is FLV (VP6) or MP4 (H.264). 
		/// </summary>
		public string FlvUrl
		{
			get;
			private set;
		}

		/// <summary>
		/// A number that uniquely identifies this Video, assigned by Brightcove when the Video is created.
		/// </summary>
		public long Id
		{
			get;
			private set;
		}

		/// <summary>
		/// One of the properties: ACTIVE, INACTIVE, or DELETED. You can set this property only to ACTIVE 
		/// or INACTIVE; you cannot delete a video by setting its itemState to DELETED.
		/// </summary>
		public ItemState ItemState
		{
			get;
			set;
		}

		/// <summary>
		/// The date this Video was last modified.
		/// </summary>
		public DateTime LastModifiedDate
		{
			get;
			private set;
		}

		/// <summary>
		/// The length of this video in milliseconds.
		/// </summary>
		public long Length
		{
			get;
			private set;
		}

		/// <summary>
		/// The text displayed for the linkURL, limited to 255 characters.
		/// </summary>
		public string LinkText
		{
			get;
			set;
		}

		/// <summary>
		/// An optional URL to a related item, limited to 255 characters.
		/// </summary>
		public string LinkUrl
		{
			get;
			set;
		}

		/// <summary>
		/// A longer description of this Video, limited to 5000 characters.
		/// </summary>
		public string LongDescription
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the video
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// How many times the Video has been played since its creation.
		/// </summary>
		public int PlaysTotal
		{
			get;
			private set;
		}

		/// <summary>
		/// How many times the Video has been played within the past seven days, excluding today.
		/// </summary>
		public int PlaysTrailingWeek
		{
			get;
			private set;
		}

		/// <summary>
		/// The date this Video was last made active.
		/// </summary>
		public DateTime PublishedDate
		{
			get;
			private set;
		}
        
		/// <summary>
		/// A user-specified id that uniquely identifies the Video, limited to 150 characters. 
		/// A referenceId can be used as a foreign-key to identify this video in another system. 
		/// Note that that the find_videos_by_reference_ids method cannot handle a referenceId 
		/// that contain commas, so you may want to avoid using commas in referenceId values.
		/// </summary>
		public string ReferenceId
		{
			get; 
			set;
		}

		/// <summary>
		/// An collection of Renditions that represent the multi-bitrate streaming renditions available for this 
		/// Video. A Video should have not more than 10 Renditions. 
		/// Note that when creating or updating a video, only one of either VideoFullLength and Renditions may 
		/// be set. If both are set, only Renditions will be submitted to the API and VideoFullLength will
		/// be ignored.
		/// Note that this property can be accessed with the Media API only with a special read or write token.
		/// </summary>
		public ICollection<BrightcoveRendition> Renditions
		{
			get;
			private set;
		}

		/// <summary>
		/// A short description describing the Video, limited to 250 characters. The 
		/// shortDescription is a required property when you create a video.
		/// </summary>
		public string ShortDescription
		{
			get;
			set;
		}

		/// <summary>
		/// The first date this Video is available to be played.
		/// </summary>
		public DateTime StartDate
		{
			get;
			set;
		}

		/// <summary>
		/// A list of Strings representing the tags assigned to this Video. Each tag can be not 
		/// more than 128 characters, and a video can have no more than 1200 tags.
		/// </summary>
		public ICollection<string> Tags
		{
			get;
			private set;
		}

		/// <summary>
		/// The URL to the thumbnail image associated with this Video. Thumbnails are 120x90 pixels.
		/// </summary>
		public string ThumbnailUrl
		{
			get;
			private set;
		}

		/// <summary>
		/// A single BrightcoveRendition that represents the the video file for the Video. 
		/// Note that when creating or updating a video, only one of either VideoFullLength and Renditions may 
		/// be set. If both are set, only Renditions will be submitted to the API and VideoFullLength will
		/// be ignored.
		/// Note that this property can be accessed with the Media API only with a special read or write token.
		/// </summary>
		public BrightcoveRendition VideoFullLength
		{
			get;
			set;
		}

		/// <summary>
		/// The URL to the video still image associated with this Video. Video stills are 480x360 pixels.
		/// </summary>
		public string VideoStillUrl
		{
			get;
			private set;
		}

		#endregion

		/// <summary>
		/// Creates an object representing a single video within Brightcove's system.
		/// </summary>
		public BrightcoveVideo()
		{
			Tags = new List<string>();
			CustomFields = new CustomFieldCollection();
			Renditions = new List<BrightcoveRendition>();
			CuePoints = new List<BrightcoveCuePoint>();
			ItemState = ItemState.Active;
			Economics = Economics.Free;
		}

		#region IJavaScriptConvertable implementation

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			IDictionary<string, object> serialized = new Dictionary<string, object>();

			serialized["customFields"] = CustomFields;
			serialized["economics"] = Economics.ToBrightcoveName();
			serialized["id"] = Id;
			serialized["itemState"] = ItemState.ToBrightcoveName();
			serialized["linkURL"] = LinkUrl;
			serialized["linkText"] = LinkText;
			serialized["longDescription"] = LongDescription;
			serialized["name"] = Name;
			serialized["referenceId"] = ReferenceId;
			serialized["shortDescription"] = ShortDescription;
			serialized["tags"] = Tags;

			// if the date is MinValue, that means it hasn't been set, so don't include it
			if (StartDate > DateTime.MinValue)
			{
				serialized["startDate"] = StartDate.ToUnixMillisecondsUtc();
			}
            if (EndDate > DateTime.MinValue)
            {
            	serialized["endDate"] = EndDate.ToUnixMillisecondsUtc();
            }

			// When creating or updating a video, only one of either VideoFullLength and Renditions may 
			// be set. If both are set, we get the following error:
			// "IllegalValueError - videoFullLength and renditions are mutually exclusive; you must set one or the other. (code 304)"
			// To prevent this exception, only submit Renditions if both are set

			// Additionally, Renditions may only be updated through the Media API in cases where they use a remote asset.
			// Don't submit renditions that lack a RemoteUrl, or the API will return an error.
			if (Renditions.Count > 0)
			{
				serialized["renditions"] = Renditions.Where(r => !String.IsNullOrEmpty(r.RemoteUrl));
			}
			else if (VideoFullLength != null && !String.IsNullOrEmpty(VideoFullLength.RemoteUrl))
			{
				serialized["videoFullLength"] = VideoFullLength;
			}
			
			if (CuePoints.Count > 0)
			{
				serialized["cuePoints"] = CuePoints;
			}

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

					case "creationDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => CreationDate = d);
						break;

					case "cuePoints":
						CuePoints = serializer.ConvertToType<BrightcoveCuePoint[]>(dictionary[key]);
						break;

					case "customFields":
						CustomFields = serializer.ConvertToType<CustomFieldCollection>(dictionary[key]);
						break;

					case "economics":
						Economics = ((string)dictionary[key]).ToBrightcoveEnum<Economics>();
						break;

					case "endDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => EndDate = d);
						break;

					case "FLVURL":
						FlvUrl = (string)dictionary[key];
						break;

					case "id":
						Id = Convert.ToInt64(dictionary[key]);
						break;
					
					case "itemState":
						ItemState = ((string) dictionary[key]).ToBrightcoveEnum<ItemState>();
						break;

					case "lastModifiedDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => LastModifiedDate = d);
						break;

					case "length":
						Length = Convert.ToInt64(dictionary[key]);
						break;

					case "linkURL":
						LinkUrl = (string)dictionary[key];
						break;

					case "linkText":
						LinkText = (string)dictionary[key];
						break;

					case "longDescription":
						LongDescription = (string)dictionary[key];
						break;

					case "name":
						Name = (string)dictionary[key];
						break;

					case "playsTotal":
						// sometimes this come back null, it seems
						if (dictionary[key] != null)
						{
							PlaysTotal = (int)dictionary[key];
						}
						break;

					case "playsTrailingWeek":
						if (dictionary[key] != null)
						{
							PlaysTrailingWeek = (int)dictionary[key];
						}
						break;

					case "publishedDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => PublishedDate = d);
						break;

					case "referenceId":
						ReferenceId = (string)dictionary[key];
						break;

					case "renditions":
						Renditions = serializer.ConvertToType<BrightcoveItemCollection<BrightcoveRendition>>(dictionary[key]);
						break;

					case "shortDescription":
						ShortDescription = (string)dictionary[key];
						break;

					case "startDate":
						DateUtil.ConvertAndSetDate(dictionary[key], d => StartDate = d);
						break;

					case "tags":
						Tags.Clear();
						Tags.AddRange(serializer.ConvertToType<string[]>(dictionary[key])); 
						break;

					case "thumbnailURL":
						ThumbnailUrl = (string)dictionary[key];
						break;

					case "videoStillURL":
						VideoStillUrl = (string)dictionary[key];
						break;

					case "videoFullLength":
						VideoFullLength = serializer.ConvertToType<BrightcoveRendition>(dictionary[key]);
						break;

					default:
						break;
				}
			}
		}

		#endregion

		
	}
}
