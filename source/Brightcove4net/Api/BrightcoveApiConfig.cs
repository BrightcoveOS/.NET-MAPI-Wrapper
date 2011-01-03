using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brightcove4net.Api
{
	public class BrightcoveApiConfig
	{
		/// <summary>
		/// The token that allows API reads for your account
		/// </summary>
		public string ReadToken
		{
			get;
			set;
		}

		/// <summary>
		/// The token that allows API writes for your account
		/// </summary>
		public string WriteToken
		{
			get;
			set;
		}

		/// <summary>
		/// The URL at which the REST API resides for reads (HTTP GET)
		/// </summary>
		public string ApiReadUrl
		{
			get;
			set;
		}

		/// <summary>
		/// The URL at which the REST API resides for writes (HTTP POST)
		/// </summary>
		public string ApiWriteUrl
		{
			get;
			set;
		}

		/// <summary>
		/// If universal delivery service is enabled for your account, set this 
		/// optional parameter to http to return video by HTTP, rather than streaming. 
		/// Meaningful only if used together with the video_fields=FLVURL, videoFullLength, 
		/// or renditions parameters. This is a MediaDeliveryTypeEnum with a value of http or default.
		/// </summary>
		public string MediaDelivery
		{
			get;
			set;
		}

		public BrightcoveApiConfig() : this(null)
		{
		}

		public BrightcoveApiConfig(string readToken) : this(readToken, null)
		{
		}
        
		public BrightcoveApiConfig(string readToken, string writeToken)
		{
			ReadToken = readToken;
			WriteToken = writeToken;
			ApiReadUrl = "http://api.brightcove.com/services/library";
			ApiWriteUrl = "http://api.brightcove.com/services/post";
		}
	}
}
