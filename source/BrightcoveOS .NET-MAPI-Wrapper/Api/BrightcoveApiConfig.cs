using System;
using System.Text;
using BrightcoveMapiWrapper.Model;

namespace BrightcoveMapiWrapper.Api
{
	/// <summary>
	/// Used to generate basic information about connections to Brightcove.
	/// </summary>
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

		/// <summary>
		/// The number of milliseconds to wait before an API request times out. 
		/// The default value is 100,000 milliseconds (100 seconds).
		/// </summary>
		public int RequestTimeout
		{
			get;
			set;
		}

		/// <summary>
		/// The encoding used when POSTing files for upload. Defaults to UTF-8.
		/// </summary>
		public Encoding Encoding
		{
			get;
			set;
		}

		/// <summary>
		/// The user agent report by this API wrapper. Defaults to "Brightcove .NET MAPI Wrapper"
		/// </summary>
		public string UserAgent
		{
			get;
			set;
		}

		/// <summary>
		/// Generic constructor.
		/// </summary>
		public BrightcoveApiConfig() : this(null)
		{
		}

		/// <summary>
		/// A read-only configuration.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		public BrightcoveApiConfig(string readToken) : this(readToken, null, BrightcoveRegion.Generic)
		{
		}

		/// <summary>
		/// A read-only configuration for the specified region.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="region">The region of the video publishing.</param>
		public BrightcoveApiConfig(string readToken, BrightcoveRegion region): this(readToken, null, region)
		{
		}

		/// <summary>
		/// A read/write configuration.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="writeToken">The authentication token provided to authorize write access to the Media APIs.</param>
		public BrightcoveApiConfig(string readToken, string writeToken) : this(readToken, writeToken, BrightcoveRegion.Generic)
		{
		}

		/// <summary>
		/// A read/write configuration for the specified region.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="writeToken">The authentication token provided to authorize write access to the Media APIs.</param>
		/// <param name="region">The region of the video publishing.</param>
		public BrightcoveApiConfig(string readToken, string writeToken, BrightcoveRegion region)
		{
			ReadToken = readToken;
			WriteToken = writeToken;

			string domain = region == BrightcoveRegion.Japan ? "co.jp" : "com";
			const string apiStem = "http://api.brightcove.{0}/services/{1}";
			ApiReadUrl = String.Format(apiStem, domain, "library");
			ApiWriteUrl = String.Format(apiStem, domain, "post");

			RequestTimeout = 100000; // .NET default
			Encoding = Encoding.UTF8;
			UserAgent = "Brightcove .NET MAPI Wrapper";
		}
	}
}
