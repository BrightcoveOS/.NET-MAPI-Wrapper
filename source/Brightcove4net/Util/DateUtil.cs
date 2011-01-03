using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brightcove4net.Util
{
	public static class DateUtil
	{
		private static DateTime UnixEpochStart
		{
			get
			{
				// Unix times start counting from 1/1/1970 0:00
				return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			}
		}

		public static DateTime FromUnixMillisecondsUtc(long milliseconds)
		{
			return UnixEpochStart.AddMilliseconds(milliseconds);
		}

		public static long ToUnixMillisecondsUtc(this DateTime utcDateTime)
		{
			TimeSpan ts = utcDateTime - UnixEpochStart;
			return (long)ts.TotalMilliseconds;
		}

		public static long ToUnixMinutesUtc(this DateTime utcDateTime)
		{
			TimeSpan ts = utcDateTime - UnixEpochStart;
			return (long)ts.TotalMinutes;
		}

		public static void ConvertAndSetDate(object dateString, Action<DateTime> setterCallback)
		{
			long milliseconds = long.Parse((string)dateString);
			setterCallback(FromUnixMillisecondsUtc(milliseconds));
		}
	}
}
