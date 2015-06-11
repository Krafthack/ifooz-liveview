using System;
using System.ComponentModel.DataAnnotations;

namespace IFoozLiveView.Models
{
    public class Goal
    {
        public int PlayerId { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH:mm:ss}" )]
        public DateTime Timestamp { get; set; }
    }
}