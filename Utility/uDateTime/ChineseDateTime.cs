using System;
using System.Globalization;

namespace Utility.uDateTime
{
    /// <summary>
    /// 
    /// </summary>
    public struct ChineseDateTime
    {
        ChineseLunisolarCalendar chineseLunisolarCalendar;
        DateTime tempDateTime;
        public DateTime DateTime {
            get {
                return tempDateTime;
            }
        }
        public int Year {
            get {
                return chineseLunisolarCalendar.GetYear(tempDateTime);
            }
        }
        public int Month {
            get
            {
                return chineseLunisolarCalendar.GetMonth(tempDateTime);
            }
        }
        public int Day {

            get
            {
                return chineseLunisolarCalendar.GetDayOfMonth(tempDateTime);
            }
        }
        public int Hour {
            get
            {
                return chineseLunisolarCalendar.GetHour(tempDateTime);
            }
        }
        public int Minute {
            get
            {
                return chineseLunisolarCalendar.GetMinute(tempDateTime);
            }
        }
        public int Second {
            get
            {
                return chineseLunisolarCalendar.GetSecond(tempDateTime);
            }
        }
        public double Millisecond {
            get
            {
                return chineseLunisolarCalendar.GetMilliseconds(tempDateTime);
            }
        }

        public static ChineseDateTime Now{
            get {
                return new ChineseDateTime(DateTime.Now);
            }
        }

        public ChineseDateTime(DateTime dateTime)
        {
            chineseLunisolarCalendar = new ChineseLunisolarCalendar();
            tempDateTime = dateTime;
        }

        public Manimals ChineseZodiac {
            get {
                return (Manimals)(Year % 12);
            }
        }

        public static TimeSpan operator -(ChineseDateTime d1, ChineseDateTime d2)
        {
            return d1.DateTime - d2.DateTime;
        }
        public static DateTime operator -(ChineseDateTime d, TimeSpan t)
        {
            return d.DateTime - t;
        }

    }
}
