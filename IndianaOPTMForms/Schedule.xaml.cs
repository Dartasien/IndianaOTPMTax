using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
using IndianaOPTMForms.Models;
using System.Xml.Serialization;

namespace IndianaOPTMForms
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Page
    {
        private bool _dataLoaded;
        public ObservableCollection<Schedule> _schedules; 

        public Schedule()
        {
            InitializeComponent();
            if (!_dataLoaded)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            if (File.Exists("schedules.xml"))
            {
                var ser = new XmlSerializer(typeof(ObservableCollection<Schedule>));
                var fileStream = new FileStream("schedules.xml", FileMode.Open);
                _schedules = (ObservableCollection<Schedule>)ser.Deserialize(fileStream);
                fileStream.Close();
                _dataLoaded = true;
            }
            else
            {
                _schedules = new ObservableCollection<Schedule>();
                _dataLoaded = true;
            }
            SchedulesListBox.ItemsSource = _schedules;
        }

        private void AddNewButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
