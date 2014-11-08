
using System.Collections.ObjectModel;


namespace IndianaOPTMForms.Models
{
    public class Schedule
    {
        public string Date { get; set; }

        public ObservableCollection<ScheduleItem> ScheduleItems { get; set; }
    }
}
