using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Xml.Serialization;
using IndianaOPTMForms.Models;
using Path = System.Windows.Shapes.Path;

namespace IndianaOPTMForms
{
    /// <summary>
    /// Interaction logic for CompanyInformation.xaml
    /// </summary>
    public partial class CompanyInformation : Page
    {
        private bool _dataLoaded;
        private CurrentCompany _currentCompany;
        private MainWindow _mainWindow = MainWindow.Current;

        public CompanyInformation()
        {
            InitializeComponent();
            LoadPageInfo();
        }

        private void LoadPageInfo()
        {
            CompanyNameBox.Text = _currentCompany.CompanyName;
            CompanyAddressBox.Text = _currentCompany.Address;
            CompanyCityBox.Text = _currentCompany.City;
            CompanyStateBox.Text = _currentCompany.State;
            ZipCodeBox.Text = _currentCompany.Zip.ToString();
            LocCodeBox.Text = _currentCompany.LocationNumber.ToString();
            StateTaxIDBox.Text = _currentCompany.StateTaxId.ToString();
            FedTaxIDBox.Text = _currentCompany.FedTaxId.ToString();
            CompanyVendorCodeBox.Text = _currentCompany.VendorCode.ToString();
            PreparerNameBox.Text = _currentCompany.PreparerName;
            PreparerPhoneNumberBox.Text = _currentCompany.PreparerPhoneNumber.ToString();
            PreparerEmailAddressBox.Text = _currentCompany.EmailAddress;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            _currentCompany.CompanyName = CompanyNameBox.Text;
            _currentCompany.Address = CompanyAddressBox.Text;
            _currentCompany.City = CompanyCityBox.Text;
            _currentCompany.State = CompanyStateBox.Text;
            _currentCompany.Zip = Convert.ToInt32(ZipCodeBox.Text);
            _currentCompany.LocationNumber = Convert.ToInt32(LocCodeBox.Text);
            _currentCompany.StateTaxId = Convert.ToInt32(StateTaxIDBox.Text);
            _currentCompany.FedTaxId = Convert.ToInt32(FedTaxIDBox.Text);
            _currentCompany.VendorCode = Convert.ToInt32(CompanyVendorCodeBox.Text);
            _currentCompany.PreparerName = PreparerNameBox.Text;
            _currentCompany.PreparerPhoneNumber = Convert.ToInt32(PreparerPhoneNumberBox.Text);
            _currentCompany.EmailAddress = PreparerEmailAddressBox.Text;

            if (File.Exists("companyinfo.xml"))
            {
                File.Delete("companyinfo.xml");
                WriteCurrentCompany();
            }
            else
            {
                WriteCurrentCompany();
            }
        }

        private void WriteCurrentCompany()
        {
            var ser = new XmlSerializer(typeof (CurrentCompany));
            var streamWriter = new StreamWriter("companyinfo.xml");
            ser.Serialize(streamWriter, _currentCompany);
            streamWriter.Close();
        }

        private void OrderCompaniesButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("OrderCompanies.xaml", UriKind.Relative));
        }

        private void SchedulesButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Schedule.xaml", UriKind.Relative));
        }
    }
}
