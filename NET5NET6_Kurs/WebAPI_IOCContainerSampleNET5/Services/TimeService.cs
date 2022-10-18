using System;

namespace WebAPI_IOCContainerSampleNET5.Services
{
    public class TimeService : ITimeService
    {
        private DateTime time;

        public TimeService()
        {
            time = DateTime.Now;
        }

        public string GetCurrentTime()
        {
            return time.ToShortTimeString();
        }
    }
}
