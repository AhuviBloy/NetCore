﻿namespace Event.Core.Models
{
    public class SingleEvent
    {
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPrice { get; set; }
        public bool EventStatus { get; set; }
        public int EventProducerId { get; set; }

        public SingleEvent(int id, string name, int price, DateTime date, int pid)
        {
            EventName = name;
            EventCode = id;
            EventPrice = price;
            EventStatus = true;
            EventProducerId = pid;
            EventDate = date;
        }
    }
}