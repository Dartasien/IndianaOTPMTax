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
using System.Xml.Serialization;
using IndianaOPTMForms.Models;

namespace IndianaOPTMForms
{
    /// <summary>
    /// Interaction logic for OrderCompanies.xaml
    /// </summary>
    public partial class OrderCompanies : Page
    {
        private bool _dataLoaded;
        private ObservableCollection<OrderCompany> _orderCompanies;

        public OrderCompanies()
        {
            InitializeComponent();
            if (!_dataLoaded)
            {
                LoadData();
            }
            OrderCompaniesListBox.ItemsSource = _orderCompanies;
        }

        private void LoadData()
        {
            if (File.Exists("ordercompanies.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<OrderCompany>));
                FileStream fileStream = new FileStream("ordercompanies.xml", FileMode.Open);
                _orderCompanies = (ObservableCollection<OrderCompany>)ser.Deserialize(fileStream);
                fileStream.Close();
                LoadPageInfo();
                _dataLoaded = true;
            }
            else
            {
                _orderCompanies = new ObservableCollection<OrderCompany>();
                _dataLoaded = true;
            }
            this.DataContext = _orderCompanies;
        }

        private void LoadPageInfo()
        {
            
        }

        private void AddNewButton_OnClick(object sender, RoutedEventArgs e)
        {
            var newCompany = CreateOrEditCompany();
            if (!_orderCompanies.Contains(newCompany))
            {
                _orderCompanies.Add(newCompany);
            }
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            CompanyNameBox.Clear();
            CompanyAddressBox.Clear();
            CompanyCityBox.Clear();
            CompanyStateBox.Clear();
            CompanyZipBox.Clear();
            CompanyFedTaxIdBox.Clear();
            UpdateOrderCompanies();
        }

        private OrderCompany CreateOrEditCompany()
        {
            var newCompany = new OrderCompany
            {
                CompanyName = CompanyNameBox.Text,
                Address = CompanyAddressBox.Text,
                City = CompanyCityBox.Text,
                State = CompanyStateBox.Text,
                Zip = Convert.ToInt32(CompanyZipBox.Text),
                FedTaxId = Convert.ToInt32(CompanyFedTaxIdBox.Text)
            };
            return newCompany;
        }

        private void UpdateOrderCompanies()
        {
            var ser = new XmlSerializer(typeof(ObservableCollection<OrderCompany>));
            var streamWriter = new StreamWriter("ordercompanies.xml");
            ser.Serialize(streamWriter, _orderCompanies);
            streamWriter.Close();
        }

        private void OrderCompaniesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedItem != null)
            {
                var newCompany = (OrderCompany)listBox.SelectedItem;
                CompanyNameBox.Text = newCompany.CompanyName;
                CompanyAddressBox.Text = newCompany.Address;
                CompanyCityBox.Text = newCompany.City;
                CompanyStateBox.Text = newCompany.State;
                CompanyZipBox.Text = newCompany.Zip.ToString();
                CompanyFedTaxIdBox.Text = newCompany.FedTaxId.ToString();
            }
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (OrderCompaniesListBox.SelectedItem != null)
            {
                if (_orderCompanies.Contains((OrderCompany) OrderCompaniesListBox.SelectedItem))
                {
                    _orderCompanies.Remove((OrderCompany) OrderCompaniesListBox.SelectedItem);
                    UpdateOrderCompanies();
                }
            }
        }

        private void UpdateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (OrderCompaniesListBox != null)
            {
                if ((OrderCompaniesListBox.SelectedItem as OrderCompany) != null)
                {
                    foreach (var company in _orderCompanies)
                    {
                        if (company.CompanyName == (OrderCompaniesListBox.SelectedItem as OrderCompany).CompanyName)
                        {
                            company.CompanyName = CompanyNameBox.Text;
                            company.Address = CompanyAddressBox.Text;
                            company.City = CompanyCityBox.Text;
                            company.State = CompanyStateBox.Text;
                            company.Zip = Convert.ToInt32(CompanyZipBox.Text);
                            company.FedTaxId = Convert.ToInt32(CompanyFedTaxIdBox.Text);
                        }
                    }
                }
            }
        }
    }
}
