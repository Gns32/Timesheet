using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimesheetApp.Models;

namespace TimesheetApp.Views
{
    /// <summary>
    /// Interaction logic for WorklogView.xaml
    /// </summary>
    public partial class WorklogView : UserControl
    {
        public WorklogView()
        {
          
            InitializeComponent();            
            
        }

        List<object> UserActivityList = new List<object>() ;
        
        public string Team { get; private set; }
        public string Title { get; private set; }

        private void ActivityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;

            if (date == null)
            {
                this.Title = "No date";
            }
            else
            {
                this.Title = date.Value.ToShortDateString();
            }
        }

        public void  LoadTimesheetData() {
            TimesheetData timesheet = new TimesheetData();
            timesheet.Team = "FMOPs";
            timesheet.WeekCommencingDate = "31-08-2020";
            timesheet.Priority = "NA";
            timesheet.ReferenceNo = "123456";
            timesheet.Release = "NA";
            timesheet.Shift = "India";
            timesheet.Description = "created data change for INC7896531";
            timesheet.Activity = "Support";
            timesheet.StartDate = "01-09-2020";
            timesheet.SpentHrs = "6";
            timesheet.Application = "Forevermark application";
            timesheet.Employee = "Ganesh Bane";


            this.UserActivityList.Add(timesheet);
            this.DataContext = this.UserActivityList;
        }

        private void StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;

            if (date == null)
            {
                this.Title = "No date";
            }
            else
            {
                this.Title = date.Value.ToShortDateString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = NewUserActivityDescription.Text;
           this.Team = "FMOPs";
            this.UserActivityList.Add(Team);
            Console.WriteLine(name);
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadTimesheetData();
        }
    }
}
