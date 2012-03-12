using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Model.Containers
{
	public interface IBrightcoveError
	{
		int Code { get; }
		string Message { get; }
	}
}
