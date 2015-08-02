using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Items
{
    /// <summary>
    /// The Captioning object represents all closed captioning files and metadata assigned to a video.
    /// </summary>
    /// <remarks>
    /// See https://docs.brightcove.com/en/video-cloud/media/references/reference.html#Captioning
    /// </remarks>
    public class BrightcoveCaptioning : BrightcoveItem, IJavaScriptConvertable
    {
        /// <summary>
        /// A number that uniquely identifies this Captioning object, 
        /// assigned by VideoCloud when this object is created.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// A set of sources which provide caption. 
        /// Only one CaptionSource is supported at this time.
        /// </summary>
        public ICollection<BrightcoveCaptionSource> CaptionSources { get; set; }

        public IDictionary<string, object> Serialize(
            JavaScriptSerializer serializer)
        {
            IDictionary<string, object> serialized = new Dictionary<string, object>();

            serialized["id"] = Id ?? 0;
            serialized["captionSources"] = CaptionSources;

            return serialized;
        }

        public void Deserialize(
            IDictionary<string, object> dictionary,
            JavaScriptSerializer serializer)
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

                    case "captionSources": 
                        CaptionSources = serializer.ConvertToType<List<BrightcoveCaptionSource>>(dictionary[key]);
                        break;
                }
            }
        }
    }
}
