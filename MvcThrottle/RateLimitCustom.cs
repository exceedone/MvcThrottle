using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcThrottle
{
    /// <summary>
    /// Rate limits custom time
    /// Ex.
    /// - RateLimitPeriod:Minute, Span:5, PerCount:10 then check between 10 minute.
    /// </summary>
    [Serializable]
    public class RateLimitCustom
    {
        /// <summary>
        /// Rate limit period. Ex. Day, month, ...
        /// </summary>
        public RateLimitPeriod RateLimitPeriod { get; set; }

        /// <summary>
        /// time span.  
        /// </summary>
        public long Span { get; set; }

        /// <summary>
        /// Limit count
        /// </summary>
        public int RateLimit { get; set; }


        public TimeSpan GetTimeSpan()
        {
            switch (RateLimitPeriod)
            {
                case RateLimitPeriod.Second:
                    return TimeSpan.FromSeconds(Span);
                case RateLimitPeriod.Minute:
                    return TimeSpan.FromMinutes(Span);
                case RateLimitPeriod.Hour:
                    return TimeSpan.FromHours(Span);
                case RateLimitPeriod.Day:
                    return TimeSpan.FromDays(Span);
                case RateLimitPeriod.Week:
                    return TimeSpan.FromDays(7 * Span);
            }

            return TimeSpan.FromDays(0);
        }
    }
}
