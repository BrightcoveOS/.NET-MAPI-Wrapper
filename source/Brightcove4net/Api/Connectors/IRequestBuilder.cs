using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Brightcove4net.Api.Connectors
{
	public interface IRequestBuilder
	{
		HttpWebRequest BuildRequest(string url);
	}
}
