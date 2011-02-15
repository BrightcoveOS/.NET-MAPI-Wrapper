using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Brightcove4net.Util;

namespace Brightcove4net.Api.Connectors
{
	public class BasicRequestBuilder : IRequestBuilder
	{
		public BrightcoveApiConfig Configuration
		{
			get;
			set;
		}

		public BasicRequestBuilder(BrightcoveApiConfig configuration)
		{
			Configuration = configuration;
		}

		public virtual HttpWebRequest BuildRequest(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Timeout = Configuration.RequestTimeout;
			return request;
		}
	}
}
