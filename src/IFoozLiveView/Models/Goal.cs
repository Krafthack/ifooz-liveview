using System;
using System.ComponentModel.DataAnnotations;

namespace IFoozLiveView.Models
{
    public class Goal
    {
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}" )]
        public DateTime Timestamp { get; set; }

        public string Team { get; set; }

        public string TimeSince(DateTime startTime)
        {
            return $"'{(Timestamp - startTime).Minutes}";
        }
    }
}