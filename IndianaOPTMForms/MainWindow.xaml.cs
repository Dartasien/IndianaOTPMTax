using System;
using System.Collections.Generic;
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

namespace IndianaOPTMForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Current;
        public OTPMModel OTPMModel;

        public MainWindow()
        {
            InitializeComponent();
            RetrieveData();
            Current = this;
            _mainFrame.Navigate(new Uri("CompanyInformation.xaml", UriKind.Relative));
        }

        private void RetrieveData()
        {
            if (OTPMModel == null)
            {
                OTPMModel = new OTPMModel();
            }
            if (!OTPMModel.IsDataLoaded)
            {
                OTPMModel.LoadData();
            }
        }
    }
}
