using System;

namespace BrightcoveMapiWrapper.Model.Containers
{
	/// <summary>
	/// Used to store field/value pairs of pertinent information.
	/// </summary>
	public class FieldValuePair
	{
		/// <summary>
		/// The field.
		/// </summary>
		public string Field
		{
			get;
			set;
		}

		/// <summary>
		/// The value.
		/// </summary>
		public string Value
		{
			get;
			set;
		}

		public FieldValuePair()
		{
		}

		public FieldValuePair(string field, string value)
		{
			Field = field;
			Value = value;
		}

		/// <summary>
		/// Turns a field/value pair into a string formatted for Brightcove's API.
		/// </summary>
		/// <returns></returns>
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
