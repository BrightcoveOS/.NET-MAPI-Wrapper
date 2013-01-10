using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;

namespace BrightcoveMapiWrapper.Api
{
	/// <summary>
	/// An Brightcove specific Exception class.
	/// </summary>
	public class BrightcoveApiException : Exception
	{
		private readonly string _message;
		/// <summary>
		/// Returns the message of the exception.
		/// </summary>
		public override string Message
		{
			get
			{
				return string.IsNullOrEmpty(_message) ? base.Message : _message;
			}
		}

		private readonly IBrightcoveError _error = null;
		/// <summary>
		/// The error passed to this exception.
		/// </summary>
		public IBrightcoveError Error
		{
			get
			{
				return _error;
			}
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public BrightcoveApiException()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="error">An encountered <see cref="BrightcoveError"/>.</param>
		public BrightcoveApiException(BrightcoveError error)
		{
			_error = error;
			_message = String.Format("An error was returned by the server while accessing the API: {0} - {1} (code {2})",
						  error.Name, error.Message, error.Code);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="nestedError">An encountered <see cref="BrightcoveNestedError"/>.</param>
		public BrightcoveApiException(BrightcoveNestedError nestedError)
		{
			_error = nestedError;

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

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public BrightcoveApiException(string message) : base(message)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
		public BrightcoveApiException(string message, Exception innerException) : base(message, innerException)
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null.</exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0).</exception>
		protected BrightcoveApiException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
