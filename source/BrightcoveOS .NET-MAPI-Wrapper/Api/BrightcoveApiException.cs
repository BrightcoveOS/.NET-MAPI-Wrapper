using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;

namespace BrightcoveMapiWrapper.Api
{
	public class BrightcoveApiException : Exception
	{
		private readonly string _message;
		public override string Message
		{
			get
			{
				return _message;
			}
		}

		public BrightcoveApiException()
		{
		}

		public BrightcoveApiException(BrightcoveError error)
		{
			_message = String.Format("An error was returned by the server while accessing the API: {0} - {1} (code {2})",
			              error.Name, error.Message, error.Code);
		}

		public BrightcoveApiException(BrightcoveNestedError nestedError)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("An error was returned by the server while accessing the API: {0} (code {1})",
			                nestedError.Message, nestedError.Code);
			
			if (nestedError.Errors.Count > 0)
			{
				sb.AppendFormat("\nThe following errors were encountered:");
				foreach (BrightcoveNestedError error in nestedError.Errors)
				{
					sb.AppendFormat("\n\t{0} (code {1})", error.Message, error.Code);
				}
			}

			_message = sb.ToString();
		}

		public BrightcoveApiException(string message) : base(message)
		{
		}

		public BrightcoveApiException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected BrightcoveApiException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
