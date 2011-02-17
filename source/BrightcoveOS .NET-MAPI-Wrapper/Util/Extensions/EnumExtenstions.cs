using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrightcoveMapiWrapper.Model;

namespace BrightcoveMapiWrapper.Util.Extensions
{
	public static class EnumExtenstions
	{
		/// <summary>
		/// Converts a Brightcove enum from it's C# representation to a plaintext string
		/// accepted by Brightcove's API
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="enumeration"></param>
		/// <returns></returns>
		public static string ToBrightcoveName<T>(this T enumeration) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			string name = enumeration.ToString();
			if (name == "None")
			{
				throw new ArgumentException("enumeration value cannot be 'None'");
			}

			// Special case: handle the SortOrder enum separately
			if (typeof(T) == typeof(SortOrder))
			{
				switch (name)
				{
					case "Ascending":
						return "ASC";

					case "Descending":
						return "DESC";
				}
			}

			// We can convert our enum names to the equivalent Brightcove representation
			// by simply inserting an underscore before each capital letter (except the first)
			// and converting to uppercase.
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < name.Length; i++)
			{
				char c = name[i];
				if (i == 0)
				{
					sb.Append(c);
					continue;
				}

				if (char.IsUpper(c))
				{
					sb.Append("_");
				}

				sb.Append(c);
			}

			return sb.ToString().ToUpper();
		}

		public static T ToBrightcoveEnum<T>(this string brightcoveEnum) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}

			if (String.IsNullOrEmpty(brightcoveEnum))
			{
				return default(T);
			}
			
			// strip out any underscores
			brightcoveEnum = brightcoveEnum.Replace("_", "");

			// Special case: handle the SortOrder enum
			if (typeof(T) == typeof(SortOrder))
			{
				switch (brightcoveEnum)
				{
					case "ASC":
						brightcoveEnum = "Ascending";
						break;

					case "DESC":
						brightcoveEnum = "Descending";
						break;
				}
			}

			// try a case-insensitive parse
			T e;
			if (EnumUtil.TryParse(brightcoveEnum, out e, true))
			{
				return e;
			}

			// no dice? return the default
			return default(T);
		}
	}
}
