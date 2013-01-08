using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// Defines a generic Brightcove error.
	/// </summary>
	public interface IBrightcoveError
	{
		/// <summary>
		/// A numeric code.
		/// </summary>
		int Code { get; }
		/// <summary>
		/// An error message.
		/// </summary>
		string Message { get; }
	}
}
