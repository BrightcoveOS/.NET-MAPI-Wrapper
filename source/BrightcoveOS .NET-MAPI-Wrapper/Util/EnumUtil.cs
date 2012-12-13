using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Util
{
	/// <summary>
	/// Maniipulates enums.
	/// </summary>
	public class EnumUtil
	{
		/// <summary>
		/// Converts the string or number representation of an enum to its equivalent enum object. 
		/// A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <typeparam name="T">Enum type</typeparam>
		/// <param name="value">Enum name or value</param>
		/// <param name="result">The resulting enum object</param>
		/// <returns>True if the conversion succeeded, otherwise false.</returns>
		public static bool TryParse<T>(string value, out T result) where T : struct
		{
			return TryParse<T>(value, out result, false);
		}

		/// <summary>
		/// Converts the string or number representation of an enum to its equivalent enum object. 
		/// A return value indicates whether the conversion succeeded.
		/// </summary>
		/// <typeparam name="T">Enum type</typeparam>
		/// <param name="value">Enum name or value</param>
		/// <param name="result">The resulting enum object</param>
		/// <param name="ignoreCase">If true, ignore case; otherwise, regard case.</param>
		/// <returns>True if the conversion succeeded, otherwise false.</returns>
		public static bool TryParse<T>(string value, out T result, bool ignoreCase) where T : struct
		{
			if (String.IsNullOrEmpty(value) || value.Trim().Length == 0)
			{
				result = default(T);
				return false;
			}

			value = value.Trim();

			//try a value/case-sensitive match first
			int intValue;
			bool isInteger = int.TryParse(value, out intValue);
			if (Enum.IsDefined(typeof(T), value) ||  //IsDefined is always case sensitive
				(isInteger && Enum.IsDefined(typeof(T), intValue)))
			{
				result = (T)Enum.Parse(typeof(T), value, true);
				return true;
			}

			//otherwise match names in a case-insensitive manner if the flag is set
			if (ignoreCase)
			{
				foreach (string name in Enum.GetNames(typeof(T)))
				{
					if (name.Equals(value, StringComparison.OrdinalIgnoreCase))
					{
						result = (T)Enum.Parse(typeof(T), name);
						return true;
					}
				}
			}

			result = default(T);
			return false;
		}
	}
}
