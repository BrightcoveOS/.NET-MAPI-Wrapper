using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Brightcove4net.Api
{
	public interface IBrightcoveApiConnector
	{
		BrightcoveApiConfig Configuration { get; set; }
		string GetResponseJson(NameValueCollection requestParams);
		string GetPostResponseJson(string postJson);
		string GetFilePostResponseJson(string postJson, string fileName, byte[] fileData);
	}
}
