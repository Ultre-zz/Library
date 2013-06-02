using System;

namespace DataConvert
{
    public class DateTimeConvert
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        public static double TimeStamp
        {
            get {
                return ToTimeStamp(DateTime.Now);
            }
        }
        /// <summary>
        /// 指定一个1970-1-1之后的时间,获取1970-1-1到这个时间之间经过的毫秒数
        /// </summary>
        /// <param name="dateTime">1970-1-1之后的时间</param>
        /// <returns>1970-1-1到指定时间之间经过的毫秒数</returns>
        public static double ToTimeStamp(DateTime dateTime)
        {
            DateTime startDateTime = DateTime.Parse("1970-1-1 0:0:0");
            TimeSpan timeSpan = dateTime - startDateTime;
            return timeSpan.TotalMilliseconds;
        }
        /// <summary>
        /// 指定一个1970-1-1之后的时间,获取1970-1-1到这个时间之间经过的毫秒数
        /// </summary>
        /// <param name="strDateTime">1970-1-1之后的时间</param>
        /// <returns>1970-1-1到指定时间之间经过的毫秒数</returns>
        public static double ToTimeStamp(string strDateTime)
        {
            DateTime endDateTime = DateTime.Parse(strDateTime);
            return ToTimeStamp(endDateTime);
        }
        /// <summary>
        /// 指定1970-1-1之后经过的毫秒数,获取时间
        /// </summary>
        /// <param name="timeStamp">1970-1-1之后经过的毫秒数</param>
        /// <returns>1970-1-1之后经过的毫秒数所到的时间</returns>
        public static DateTime ToDateTime(double timeStamp)
        {
            DateTime startDateTime = DateTime.Parse("1970-1-1 0:0:0");
            return startDateTime.AddMilliseconds(timeStamp);
        }
    }
}
