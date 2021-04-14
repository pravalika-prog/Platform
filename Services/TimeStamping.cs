using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.Services
{
    public class TimeStamping
    {
        public interface ITimeStamper
        {
            string TimeStamp { get; }
        }
        public class DefaultTimeStamper : ITimeStamper
        {
            public string TimeStamp => DateTime.Now.ToShortTimeString();
        }
    }
}
