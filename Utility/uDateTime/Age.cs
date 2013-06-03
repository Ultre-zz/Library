using System;

namespace Utility.uDateTime
{
    public class Age
    {
        /// <summary>
        /// 出生日期(阳历)
        /// </summary>
        public DateTime BirthDay { get;set; }

        /// <summary>
        /// 获取年龄
        /// </summary>
        /// <returns></returns>
        public uint GetAge()
        { 
            
            uint age=(uint)(DateTime.Now.Year-BirthDay.Year);
            if (DateTime.Now.Month < BirthDay.Month)
            {
                age--;
            }
            else if (DateTime.Now.Month < BirthDay.Month)
            {
                if (DateTime.Now.Day < BirthDay.Day)
                {
                    age--;
                }
            }
            return age;
        }
    }
}
