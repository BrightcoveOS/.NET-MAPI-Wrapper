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
	/// The BrightcoveImage object represents an image file in Brightcove's system. Images are associated with videos as 
	/// thumbnail images, video still images, or logo overlays. An image can be a JPEG, GIF, or PNG-formatted image. Note 
	/// that when creating a new image asset, the only property that is required is type. If you are not uploading a file, 
	/// the remoteUrl property is also required.
	/// </summary>
	public class BrightcoveImage : BrightcoveItem, IJavaScriptConvertable
	{
		/// <summary>
		/// A number that uniquely identifies the Image. This id is automatically 
		/// assigned by Brightcove when the Image is created.
		/// </summary>
		public long Id
		{
			get;
			private set;
		}

		/// <summary>
		/// A user-specified id that uniquely identifies this Image.
		/// </summary>
		public string ReferenceId
		{
			get;
			set;
		}

		/// <summary>
		/// THUMBNAIL, VIDEO_STILL, or LOGO_OVERLAY. The type is writable and required 
		/// when you create an Image; it cannot subsequently be changed.
		/// </summary>
		public ImageType Type
		{
			get;
			set;
		}

		/// <summary>
		/// The URL of a remote image file. This property is required if you are not uploading a 
		/// file for the image asset.
		/// </summary>
		public string RemoteUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The name of the asset, which will be displayed in the Media module.
		/// </summary>
		public string DisplayName
		{
			get;
			set;
		}

		#region IJavaScriptConvertable implementation

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
			
			serialized["referenceId"] = ReferenceId;
			serialized["type"] = Type.ToBrightcoveName();
			serialized["remoteUrl"] = RemoteUrl;
			serialized["displayName"] = DisplayName;

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

					case "displayName":
						DisplayName = (string)dictionary[key];
						break;

					case "id":
						Id = Convert.ToInt64(dictionary[key]);
						break;

					case "remoteUrl":
						RemoteUrl = (string) dictionary[key];
						break;

					case "type":
						Type = ((string) dictionary[key]).ToBrightcoveEnum<ImageType>();
						break;
				}
			}
		}

		#endregion
	}
}
