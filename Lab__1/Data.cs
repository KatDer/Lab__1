using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab__1
{
    public enum EventType
    {
        TASK = 0,
        METEENG = 1,
    }

    public struct Data
    {
        public string Event { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public EventType EventType { get; set; }

        public Data(String Event, DateTime Date, TimeSpan Time, EventType eventType)
        {
            this.Event = Event;
            this.Date = Date;
            this.Time = Time;
            this.EventType = eventType;
        }
    }
}
