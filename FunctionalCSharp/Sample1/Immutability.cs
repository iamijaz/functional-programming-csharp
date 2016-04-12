using System;
using System.Collections.Generic;

namespace FunctionalCSharp.Sample1
{
    public class DateRange
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool DateIsInRange(DateTime checkDate)
        {
            return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
        }


        void Main2()
        {
            var testDates =
                new List<DateTime>
                {
                    DateTime.Parse("2015-11-03"),
                    DateTime.Parse("2015-11-01"),
                    DateTime.Parse("2015-10-01"),
                    DateTime.Parse("2015-12-01")
                };

            var range = new DateRange {Start = DateTime.Parse("2015-11-01"), End = DateTime.Parse("2015-11-06")};

            //testDates.ForEach(d => $"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}".Dump());
        }
    }
}