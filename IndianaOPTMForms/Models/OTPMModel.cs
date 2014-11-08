using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IndianaOPTMForms.Models
{
    public class OTPMModel
    {
        private ObservableCollection<OrderCompany> _orderCompanies;
        public ObservableCollection<OrderCompany> OrderCompanies
        {
            get { return _orderCompanies; }
            set { _orderCompanies = value; }
        }

        private ObservableCollection<Schedule> _schedules;
        public ObservableCollection<Schedule> Schedules
        {
            get { return _schedules; }
            set { _schedules = value; }
        }

        private ObservableCollection<ScheduleItem> _scheduleItems;

        public ObservableCollection<ScheduleItem> ScheduleItems
        {
            get { return _scheduleItems; }
            set { _scheduleItems = value; }
        }

        private CurrentCompany _companyinfo;

        public CurrentCompany CompanyInfo
        {
            get { return _companyinfo; }
            set { _companyinfo = value; }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            if (!IsDataLoaded)
            {
                LoadData("companyinfo.xml", 0);
                LoadData("ordercompanies.xml", 1);
                LoadData("schedules.xml", 2);
            }
        }

        private void LoadData(string fileName, int version)
        {
            if (File.Exists(fileName))
            {
                XmlSerializer ser;
                FileStream fileStream;
                switch (version)
                {
                    case 0:
                        ser = new XmlSerializer(typeof (CurrentCompany));
                        fileStream = new FileStream(fileName, FileMode.Open);
                        CompanyInfo = (CurrentCompany) ser.Deserialize(fileStream);
                        fileStream.Close();
                        break;
                    case 1:
                        ser = new XmlSerializer(typeof(ObservableCollection<OrderCompany>));
                        fileStream = new FileStream(fileName, FileMode.Open);
                        OrderCompanies = (ObservableCollection<OrderCompany>) ser.Deserialize(fileStream);
                        fileStream.Close();
                        break;
                    case 2:
                        ser = new XmlSerializer(typeof(Schedule));
                        fileStream = new FileStream(fileName, FileMode.Open);
                        Schedules = (ObservableCollection<Schedule>) ser.Deserialize(fileStream);
                        fileStream.Close();
                        break;
                }
            }
            else
            {
                switch (version)
                {
                    case 0:
                        CompanyInfo = new CurrentCompany();
                        break;
                    case 1:
                        OrderCompanies = new ObservableCollection<OrderCompany>();
                        break;
                    case 2:
                        Schedules = new ObservableCollection<Schedule>();
                        break;
                }
            }
        }
    }
}
