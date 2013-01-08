using System;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// Used to store field/value pairs of pertinent Brightcove parameter information.
	/// </summary>
	public class FieldValuePair
	{
		/// <summary>
		/// The name of the field.
		/// </summary>
		public string Field
		{
			get;
			set;
		}

		/// <summary>
		/// The string representation of the value.
		/// </summary>
		public string Value
		{
			get;
			set;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		public FieldValuePair()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="field">The name of the field.</param>
		/// <param name="value">The string representation of the value.</param>
		public FieldValuePair(string field, string value)
		{
			Field = field;
			Value = value;
		}

		/// <summary>
		/// Turns a field/value pair into a string formatted for Brightcove's API.
		/// </summary>
		/// <returns>A correctly formatted string for Brightcove's API.</returns>
		public string ToBrightcoveString()
		{
			if (!String.IsNullOrEmpty(Field))
			{
				return String.Format("{0}:{1}", Field, Value);
			}
			return Value;
		}
	}
}
