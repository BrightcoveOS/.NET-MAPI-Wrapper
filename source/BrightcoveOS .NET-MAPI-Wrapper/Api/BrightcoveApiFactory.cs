using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Api.Connectors;
using BrightcoveMapiWrapper.Model;

namespace BrightcoveMapiWrapper.Api
{
	/// <summary>
	/// Creates instances of <see cref="BrightcoveApi"/>.
	/// </summary>
	public class BrightcoveApiFactory
	{
		/// <summary>
		/// Creates an API object for read-only API access.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken)
		{
			return CreateApi(readToken, null);
		}

		/// <summary>
		/// Creates an API object for read/write API access.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="writeToken">The authentication token provided to authorize write access to the Media APIs.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken, string writeToken)
		{
			return CreateApi(readToken, writeToken, null);
		}

		/// <summary>
		/// Creates an API object for read/write API access with a custom "media delivery" format.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="writeToken">The authentication token provided to authorize write access to the Media APIs.</param>
		/// <param name="mediaDelivery">The format for media delivery. Specify "http" to retrieve URLs for downloading 
		/// audio &amp; video files, rather than streaming them.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken, string writeToken, string mediaDelivery)
		{
			return CreateApi(readToken, writeToken, mediaDelivery, BrightcoveRegion.Generic);
		}

		/// <summary>
		/// Creates an API object for read-only API access for a specific region.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="region">The region of the video publishing.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken, BrightcoveRegion region)
		{
			return CreateApi(readToken, null, region);
		}

		/// <summary>
		/// Creates an API object for read/write API access for a specific region.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="writeToken">The authentication token provided to authorize write access to the Media APIs.</param>
		/// <param name="region">The region of the video publishing.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken, string writeToken, BrightcoveRegion region)
		{
			return CreateApi(readToken, writeToken, null, region);
		}

		/// <summary>
		/// Creates an API object for read/write API access for a specific region and with a custom "media delivery" format.
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <param name="writeToken">The authentication token provided to authorize write access to the Media APIs.</param>
		/// <param name="mediaDelivery">The format for media delivery. Specify "http" to retrieve URLs for downloading 
		/// audio &amp; video files, rather than streaming them.</param>
		/// <param name="region">The region of the video publishing.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken, string writeToken, string mediaDelivery, BrightcoveRegion region)
		{
			BrightcoveApiConfig apiConfig = new BrightcoveApiConfig(readToken, writeToken, region);
			if (!String.IsNullOrEmpty(mediaDelivery))
			{
				apiConfig.MediaDelivery = mediaDelivery;
			}

			BrightcoveApiConnector apiConnector = new BrightcoveApiConnector(apiConfig);
			return new BrightcoveApi(apiConnector);
		}
	}
}
