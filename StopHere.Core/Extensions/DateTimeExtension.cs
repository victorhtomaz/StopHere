﻿using System.Reflection.Metadata.Ecma335;

namespace StopHere.Core.Extensions;

public static class DateTimeExtension
{
    public static DateTime GetFirstDay(this DateTime dateTime, int? year = null, int? month = null) 
        => new DateTime(year ?? dateTime.Year, month ?? dateTime.Month, 1);

    public static DateTime GetLastDay(this DateTime dateTime, int? year = null, int? month = null)
        => new DateTime(year ?? dateTime.Year, month ?? dateTime.Month, 1).AddMonths(1).AddDays(-1);
}
