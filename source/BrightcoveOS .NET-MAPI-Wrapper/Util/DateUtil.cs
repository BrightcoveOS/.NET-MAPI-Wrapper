using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightcoveMapiWrapper.Util
{
	/// <summary>
	/// Primarily functions to convert .NET time to Unix time.
	/// </summary>
	public static class DateUtil
	{
		/// <summary>
		/// Gets the Unix epoch start.
		/// </summary>
		/// <value>
		/// The Unix epoch start.
		/// </value>
		private static DateTime UnixEpochStart
		{
			get
			{
				// Unix times start counting from 1/1/1970 0:00
				return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			}
		}

		/// <summary>
		/// Adds a specified number of milliseconds to the start of the Unix epoch.
		/// </summary>
		/// <param name="milliseconds">The specified number of milliseconds to add.</param>
		/// <returns></returns>
		public static DateTime FromUnixMillisecondsUtc(long milliseconds)
		{
			return UnixEpochStart.AddMilliseconds(milliseconds);
		}

		/// <summary>
		/// Converts a <see cref="DateTime"/> object in UTC to Unix milliseconds.
		/// </summary>
		/// <param name="utcDateTime">The <see cref="DateTime"/> object in UTC.</param>
		/// <returns>The number of milliseconds.</returns>
		public static long ToUnixMillisecondsUtc(this DateTime utcDateTime)
		{
			TimeSpan ts = utcDateTime - UnixEpochStart;
			return (long)ts.TotalMilliseconds;
		}

		/// <summary>
		/// Converts a <see cref="DateTime"/> object in UTC to Unix minutes.
		/// </summary>
		/// <param name="utcDateTime">The <see cref="DateTime"/> object in UTC.</param>
		/// <returns></returns>
		public static long ToUnixMinutesUtc(this DateTime utcDateTime)
		{
			TimeSpan ts = utcDateTime - UnixEpochStart;
			return (long)ts.TotalMinutes;
		}

		/// <summary>
		/// Converts the number of milliseconds represented as a string and adds it to the<see cref="DateTime"/> specified in the <paramref name="setterCallback"/> action.
		/// </summary>
		/// <param name="dateString">The number of milliseconds as a <see cref="string"/>.</param>
		/// <param name="setterCallback">The action to perform.</param>
		/// <exception cref="InvalidCastException"><paramref name="dateString"/> is not a string.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="dateString"/> is null.</exception>
		/// <exception cref="FormatException"><paramref name="dateString"/> is in the wrong format.</exception>
		/// <exception cref="OverflowException"><paramref name="dateString"/> represents a number less than MinValue or greater than MaxValue.</exception>
		public static void ConvertAndSetDate(object dateString, Action<DateTime> setterCallback)
		{
			if (dateString == null)
			{
				setterCallback(DateTime.MinValue);
				return;
			}

			long milliseconds = long.Parse((string)dateString);
			setterCallback(FromUnixMillisecondsUtc(milliseconds));
		}
	}
}
