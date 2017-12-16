using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Net.Http;
using Pso2Notifier.Models;
using System.Diagnostics;


using System.Net.Http.Headers;
namespace Pso2Notifier
{
    class Utility
    {
        public static readonly TimeZoneInfo JPTimeInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
        /// <summary>
        /// Japan Standard Time to User's Timezone
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static DateTime JapanTimeToLocal(int hour, int minutes)
        {
            var currentDate = DateTime.Now;
            var selectedTimeZone = TimeZoneInfo.Local;
            var EQDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, hour, minutes, 0);
            var localEQDateIn = TimeZoneInfo.ConvertTime(EQDate, JPTimeInfo, selectedTimeZone);
            return localEQDateIn;
        }
    }
}
