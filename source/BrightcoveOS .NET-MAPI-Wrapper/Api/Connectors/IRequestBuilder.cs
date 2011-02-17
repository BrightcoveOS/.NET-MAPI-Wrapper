using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;

namespace BrightcoveMapiWrapper.Api.Connectors
{
	public interface IRequestBuilder
	{
		HttpWebRequest BuildRequest(string url);
		HttpWebRequest BuildPostFormRequest(string postUrl, NameValueCollection postParameters);
		HttpWebRequest BuildMultipartFormDataPostRequest(string postUrl, NameValueCollection postParameters, FileParameter fileParameter);
	}
}
