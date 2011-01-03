using System;

namespace Brightcove4net.Model.Containers
{
	public class FieldValuePair
	{
		public string Field
		{
			get;
			set;
		}

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
