using System;
using System.Collections.Generic;
using System.Text;

namespace _04_OutingsRepository
{
    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
    public class Outing
    {
        public int Attendance { get; set; }
        public DateTime EventDate { get; set; }
        public float CostPerPerson { get; set; }
        public float TotalEventCost
        {
            get
            { Attendance*CostPerPerson}
        }

        public Outing() { }

        public Outing(int attendance, DateTime eventDate, float costPerPerson)
        {
            Attendance = attendance;
            EventDate = eventDate;
            CostPerPerson = costPerPerson;
        }
    }
}
