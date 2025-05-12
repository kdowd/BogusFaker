using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bogus;
using Bogus.DataSets;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var customer = new Faker<Customer>();
            customer.RuleFor(x => x.CompanyName, f => f.Company.CompanyName());
            customer.RuleFor(x => x.Address, f => f.Address.FullAddress());
            customer.RuleFor(x => x.FirstName, f => f.Name.FirstName());
            customer.RuleFor(x => x.ID, f => (uint)f.Random.Int());

            var customers = customer.Generate(3);

            MessageBox.Show(customers.Count.ToString());

            //foreach (Customer item in customers)
            //{
            //    MessageBox.Show(item.ID.ToString());
            //}

        }
    }

    public class Customer
    {
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public uint? ID { get; set; }

        public Customer()
        {

        }
    }
}