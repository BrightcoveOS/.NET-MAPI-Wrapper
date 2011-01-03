using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brightcove4net.Api
{
	public class BrightcoveApiFactory
	{
		/// <summary>
		/// Creates an API object for read-only API access
		/// </summary>
		/// <param name="readToken">The authentication token provided to authorize read access to the Media APIs.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken)
		{
			return CreateApi(readToken, null);
		}

		/// <summary>
		/// Creates an API object for read/write API access
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
		/// audio & video files, rather than streaming them.</param>
		/// <returns>A configured BrightcoveApi object</returns>
		public static BrightcoveApi CreateApi(string readToken, string writeToken, string mediaDelivery)
		{
			BrightcoveApiConfig apiConfig = new BrightcoveApiConfig();
			apiConfig.ReadToken = readToken;
			apiConfig.WriteToken = writeToken;
			if (!String.IsNullOrEmpty(mediaDelivery))
			{
				apiConfig.MediaDelivery = mediaDelivery;
			}
			
			BrightcoveApiConnector apiConnector = new BrightcoveApiConnector(apiConfig);
			return new BrightcoveApi(apiConnector);
		}
	}
}
