﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackiCore.Extensions
{
    /// <summary>
    /// From: http://stackoverflow.com/questions/38039/how-can-i-get-the-datetime-for-the-start-of-the-week
    /// </summary>
    public class DateTimeExtensions
    {
        public DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }
    }
}
