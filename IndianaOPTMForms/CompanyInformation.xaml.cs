using System;
using System.IO;

using System.Windows;
using System.Windows.Controls;
using IndianaOPTMForms.Models;


namespace IndianaOPTMForms
{
    /// <summary>
    /// Interaction logic for CompanyInformation.xaml
    /// </summary>
    public partial class CompanyInformation : Page
    {
        private readonly MainWindow _mainWindow = MainWindow.Current;

        public CompanyInformation()
        {
            InitializeComponent();
            if (!_mainWindow.OTPMModel.IsDataLoaded)
            {
                _mainWindow.OTPMModel.LoadData();
            }
            this.DataContext = _mainWindow.OTPMModel.CompanyInfo;
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.OTPMModel.CompanyInfo.CompanyName = CompanyNameBox.Text;
            _mainWindow.OTPMModel.CompanyInfo.Address = CompanyAddressBox.Text;
            _mainWindow.OTPMModel.CompanyInfo.City = CompanyCityBox.Text;
            _mainWindow.OTPMModel.CompanyInfo.State = CompanyStateBox.Text;
            _mainWindow.OTPMModel.CompanyInfo.Zip = Convert.ToInt32(ZipCodeBox.Text);
            _mainWindow.OTPMModel.CompanyInfo.LocationNumber = Convert.ToInt32(LocCodeBox.Text);
            _mainWindow.OTPMModel.CompanyInfo.StateTaxId = Convert.ToInt32(StateTaxIDBox.Text);
            _mainWindow.OTPMModel.CompanyInfo.FedTaxId = Convert.ToInt32(FedTaxIDBox.Text);
            _mainWindow.OTPMModel.CompanyInfo.VendorCode = Convert.ToInt32(CompanyVendorCodeBox.Text);
            _mainWindow.OTPMModel.CompanyInfo.PreparerName = PreparerNameBox.Text;
            _mainWindow.OTPMModel.CompanyInfo.PreparerPhoneNumber = Convert.ToInt32(PreparerPhoneNumberBox.Text);
            _mainWindow.OTPMModel.CompanyInfo.EmailAddress = PreparerEmailAddressBox.Text;

            if (File.Exists("companyinfo.xml"))
            {
                File.Delete("companyinfo.xml");
                _mainWindow.OTPMModel.WriteData("companyinfo.xml", 0);
            }
            else
            {
                _mainWindow.OTPMModel.WriteData("companyinfo.xml", 0);
            }
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
