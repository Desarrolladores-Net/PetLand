using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Services.Time;

namespace Services.Time
{
    public class TimeManager : ITimeManager
    {
        public DateTime GetCubanTime(DateTime date)
        {
            var cubanZone = TimeZoneInfo.FindSystemTimeZoneById("Cuba Standard Time");

            var timeCuba = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cubanZone);

            return timeCuba;
        }
    }
}