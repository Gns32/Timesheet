using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimesheetWebApi.Models
{
    public class Timesheet
    {
        public string WeekCommencingDate { get; set; }
        public string Team { get; set; }
        public string Shift { get; set; }
        public string Employee { get; set; }
        public string ReferenceNo { get; set; }
        public string Activity { get; set; }
        public string Realese { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string SpentHrs { get; set; }
    }
}
