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
	/// The BrightcoveCuePoint object is a marker set at a precise time point in the duration of a video. You can 
	/// use cue points to trigger mid-roll ads or to separate chapters or scenes in a long-form video. 
	/// </summary>
	public class BrightcoveCuePoint : BrightcoveItem, IJavaScriptConvertable
	{
		/// <summary>
		/// Required. A name for the cue point so that you can refer to it.
		/// </summary>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Although the API docs say that this field is "A list of the ids of one or more videos that 
		/// this cue point applies to", it appears that in practice this is actually only a single video
		/// ID, and not a comma-separated list.
		/// </summary>
		public long VideoId
		{
			get;
			private set;
		}

		/// <summary>
		/// Required. The time of the cue point, measured in milliseconds from the 
		/// beginning of the video.
		/// </summary>
		public long Time
		{
			get;
			set;
		}

		/// <summary>
		/// If true, the video stops playback at the cue point. This setting is valid only 
		/// for AD type cue points.
		/// </summary>
		public bool ForceStop
		{
			get;
			set;
		}

		/// <summary>
		/// A string that can be passed along with a CODE cue point. Not more than 512 characters.
		/// </summary>
		public string MetaData
		{
			get;
			set;
		}

		/// <summary>
		/// Required. An integer code corresponding to the type of cue point. One of AD or CODE. 
		/// An Ad cue point is used to trigger mid-roll ad requests. A Code cue point can be used 
		/// to indicate a chapter or scene break in the video.
		/// </summary>
		public CuePointType Type
		{
			get;
			set;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public BrightcoveCuePoint()
		{
			Type = CuePointType.Code;
		}

		/// <summary>
		/// Serializes the specified serializer.
		/// </summary>
		/// <param name="serializer">The serializer.</param>
		/// <returns>
		/// A serialized <see cref="IDictionary{String,Object}" />.
		/// </returns>
		public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
		{
			IDictionary<string, object> serialized = new Dictionary<string, object>();

			serialized["name"] = Name;
			
			if (VideoId > 0)
			{
				serialized["videoId"] = VideoId;
			}
			
			serialized["time"] = Time;
			serialized["forceStop"] = ForceStop.ToString().ToLower();

			// Strangely, unlike every single other place where the API specifies an enum value,
			// we use integer values here instead of text.
			serialized["type"] = Type == CuePointType.Ad ? 0 : 1;

			serialized["metadata"] = MetaData;

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

					case "forceStop":
						ForceStop = (bool)dictionary[key];
						break;

					case "metadata":
						MetaData = (string) dictionary[key];
						break;

					case "name":
						Name = (string)dictionary[key];
						break;

					case "time":
						Time = Convert.ToInt64(dictionary[key]);
						break;

					case "type":
						// Strangely, unlike every single other place where the API specifies an enum value,
						// we use integer values here instead of text.
						int value = (int) dictionary[key];
						Type = value == 0 ? CuePointType.Ad : CuePointType.Code;
						break; 

					case "videoId":
						// Although the API docs say that this field is "A list of the ids of one or more videos that 
						// this cue point applies to", it appears that in practice this is actually only a single video
						// ID, and not a comma-separated list.
						VideoId = Convert.ToInt64(dictionary[key]);
						break;

					default:
						break;
				}
			}
		}
	}
}
