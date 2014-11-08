
namespace IndianaOPTMForms.Models
{
    public class ScheduleItem
    {
        public string TransactionType { get; set; }

        public string DocumentType { get; set; }

        public string DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        public string CompanyName { get; set; }

        public int FedTaxId { get; set; }

        public int LicenseNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public int WholesalePrice { get; set; }

        public int NumberOfOunces { get; set; }
    }
}