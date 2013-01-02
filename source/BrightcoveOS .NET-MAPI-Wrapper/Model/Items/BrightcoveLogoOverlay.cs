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
	/// The BrightcoveLogoOverlay object represents a logo overlay assigned to a video. The logo overlay is displayed 
	/// over a portion of the video display for the entire duration of the video.
	/// </summary>
	public class BrightcoveLogoOverlay : BrightcoveItem, IJavaScriptConvertable
	{
		/// <summary>
		/// A number that uniquely identifies the LogoOverlay. This id is automatically assigned 
		/// by Brightcove when the LogoOverlay is created.
		/// </summary>
		public long Id
		{
			get;
			private set;
		}

		/// <summary>
		/// A BrightcoveImage object, defined by its id or referenceId, with type=LOGO_OVERLAY.
		/// </summary>
		public BrightcoveImage Image
		{
			get;
			set;
		}

		/// <summary>
		/// Optional. A text that is displayed when the viewer mouses over the logo overlay.
		/// </summary>
		public string Tooltip
		{
			get;
			set;
		}

		/// <summary>
		/// Optional. A URL to go to if the viewer clicks on the logo overlay.
		/// </summary>
		public string LinkUrl
		{
			get;
			set;
		}

		/// <summary>
		/// Optional. A LogoOverlayAlignmentEnum representing the orientation of the logo overlay 
		/// relative to the video display. One of the following values: TOP_LEFT, BOTTOM_LEFT, 
		/// TOP_RIGHT, or BOTTOM_RIGHT. The default is BOTTOM_RIGHT.
		/// </summary>
		public LogoOverlayAlignment Alignment
		{
			get;
			set;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public BrightcoveLogoOverlay()
		{
			Alignment = LogoOverlayAlignment.BottomRight;
		}

		#region Implementation of IJavaScriptConvertable

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

			if (Id > 0)
			{
				serialized["id"] = Id;
			}
			serialized["image"] = Image;
			serialized["tooltip"] = Tooltip;
			serialized["linkURL"] = LinkUrl;
			serialized["alignment"] = Alignment.ToBrightcoveName();

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

					case "id":
						Id = Convert.ToInt64(dictionary[key]);
						break;

					case "image":
						Image = serializer.ConvertToType<BrightcoveImage>(dictionary[key]);
						break;

					case "tooltip":
						Tooltip = (string) dictionary[key];
						break;

					case "linkURL":
						LinkUrl = (string) dictionary[key];
						break;

					case "alignment":
						Alignment = ((string) dictionary[key]).ToBrightcoveEnum<LogoOverlayAlignment>();
						break;
				}
			}
		}

		#endregion
	}
}
