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
	/// The BrightcoveRendition object represents one of the multi-bitrate streaming renditions of a video.
	/// A Video should have not more than 10 Rendition objects.
	/// </summary>
	public class BrightcoveRendition : BrightcoveItem, IJavaScriptConvertable
	{
		/// <summary>
		/// [Optional — required for live streaming only] Depending on your CDN, one of the following 
		/// values: LIMELIGHT_LIVE or AKAMAI_LIVE.
		/// </summary>
		public ControllerType ControllerType
		{
			get;
			set;
		}

		/// <summary>
		/// The rendition's encoding rate, in bits per second.
		/// </summary>
		public int EncodingRate
		{
			get;
			private set;
		}

		/// <summary>
		/// The rendition's display height, in pixels.
		/// </summary>
		public int FrameHeight
		{
			get;
			private set;
		}

		/// <summary>
		/// The rendition's display width, in pixels.
		/// </summary>
		public int FrameWidth
		{
			get;
			private set;
		}

		/// <summary>
		/// The file size of the rendition, in bytes.
		/// </summary>
		public long Size
		{
			get;
			private set;
		}

		/// <summary>
		/// Required, for remote assets. The complete path to the file hosted on the remote server. 
		/// If the file is served using progressive download, then you must include the file name 
		/// and extension for the file. You can also use a URL that re-directs to a URL that includes 
		/// the file name and extension. If the file is served using Flash streaming, use the 
		/// remoteStreamName attribute to provide the stream name.
		/// </summary>
		public string RemoteUrl
		{
			get;
			set;
		}

		/// <summary>
		/// [Optional — required for streaming remote assets only] A stream name for Flash streaming 
		/// appended to the value of the remoteUrl property.
		/// </summary>
		public string RemoteStreamName
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of the rendition file.
		/// </summary>
		public string Url
		{
			get;
			private set;
		}

		/// <summary>
		/// The length of the remote video asset in milliseconds.
		/// </summary>
		public long VideoDuration
		{
			get;
			private set;
		}

		/// <summary>
		/// Valid values are SORENSON, ON2, and H264.
		/// </summary>
		public VideoCodec VideoCodec
		{
			get;
			set;
		}

		/// <summary>
		/// (I can't actually find this property defined in any documentation,
		/// but it's returned by the API and seems useful)
		/// The container in which the video resides. Will generally be either "MP4" or "VP6" (flash).
		/// </summary>
		public string VideoContainer
		{
			get;
			private set;
		}

		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			IDictionary<string, object> serialized = new Dictionary<string, object>();

			serialized["controllerType"] = ControllerType.ToBrightcoveName();
			serialized["remoteUrl"] = RemoteUrl;
			serialized["remoteStreamName"] = RemoteStreamName;
			serialized["size"] = Size;
			serialized["videoDuration"] = VideoDuration;
			serialized["videoCodec"] = VideoCodec.ToBrightcoveName();

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

					case "controllerType":
						ControllerType = ((string)dictionary[key]).ToBrightcoveEnum<ControllerType>();
						break;

					case "encodingRate":
						if (dictionary[key] != null)
						{
							EncodingRate = (int)dictionary[key];
						}
						break;

					case "frameHeight":
						if (dictionary[key] != null)
						{
							FrameHeight = (int) dictionary[key];
						}
						break;

					case "frameWidth":
						if (dictionary[key] != null)
						{
							FrameWidth = (int) dictionary[key];
						}
						break;

					case "remoteUrl":
						RemoteUrl = (string)dictionary[key];
						break;

					case "remoteStreamName":
						RemoteStreamName = (string)dictionary[key];
						break;

					case "size":
						Size = Convert.ToInt64(dictionary[key]);
						break;

					case "url":
						Url = (string) dictionary[key];
						break;

					case "videoDuration":
						VideoDuration = Convert.ToInt64(dictionary[key]);
						break;

					case "videoCodec":
						VideoCodec = ((string)dictionary[key]).ToBrightcoveEnum<VideoCodec>();
						break;

					case "videoContainer":
						VideoContainer = (string) dictionary[key];
						break;
				}
			}
		}
	}
}
