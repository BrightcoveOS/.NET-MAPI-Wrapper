using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Items
{
    /// <summary>
    /// A source that provides captions for a video
    /// </summary>
    /// <remarks>
    /// See https://docs.brightcove.com/en/video-cloud/media/references/reference.html#CaptionSource
    /// </remarks>
    public class BrightcoveCaptionSource : BrightcoveItem, IJavaScriptConvertable
    {
        /// <summary>
        /// A number that uniquely identifies this CaptionSource object, 
        /// assigned by Video Cloud when this object is created.
        /// </summary>
        public long? Id { get; private set; }

        /// <summary>
        /// A Boolean indicating whether or not this CaptionSource is hosted on a remote server, 
        /// as opposed to hosted by Brightcove.
        /// </summary>
        public bool IsRemote { get; private set; }

        /// <summary>
        /// A Boolean indicating whether a CaptionSource is usable.
        /// </summary>
        public bool Complete { get; private set; }

        /// <summary>
        /// The name of the caption source, which will be displayed in the Media module.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The complete path to the file.
        /// </summary>
        public string Url { get; set; }

        public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
        {
            IDictionary<string, object> serialized = new Dictionary<string, object>();

            serialized["complete"] = Complete;
            serialized["displayName"] = DisplayName;
            serialized["id"] = Id ?? 0;
            serialized["isRemote"] = IsRemote;
            serialized["url"] = Url;

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

                    case "complete":
                        Complete = Convert.ToBoolean(dictionary[key]);
                        break;

                    case "displayName":
                        DisplayName = Convert.ToString(dictionary[key]);
                        break;

                    case "id":
                        Id = Convert.ToInt64(dictionary[key]);
                        break;

                    case "isRemote":
                        IsRemote = Convert.ToBoolean(dictionary[key]);
                        break;

                    case "url":
                        Url = Convert.ToString(dictionary[key]);
                        break;
                }
            }
        }
    }
}
