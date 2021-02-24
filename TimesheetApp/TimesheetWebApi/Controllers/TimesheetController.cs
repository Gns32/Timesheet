using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimesheetWebApi.Models;

namespace TimesheetWebApi.Controllers
{
    public class TimesheetController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<object> Get()
        {
            List<Timesheet> timesheetList = new List<Timesheet>();

            var timesheetData = new Timesheet();
            timesheetData.WeekCommencingDate = "31-08-2020";
            timesheetData.Team = "Forevermark Operations";
            timesheetData.Shift = "India";
            timesheetData.Employee = "Ganesh";
            timesheetData.ReferenceNo = "NA";
            timesheetData.Activity = "Support";
            timesheetData.Realese = "NA";
            timesheetData.Priority = "low";
            timesheetData.Description = "Missing PDF update";
            timesheetData.StartDate = "31-08-2020";
            timesheetData.SpentHrs = "2";
            timesheetList.Add(timesheetData);
            return timesheetList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}