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
using WpfApp1.DBConnection;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReadersPagee.xaml
    /// </summary>
    public partial class ReadersPagee : Page
    {
        public static List<Employee> employees { get; set; }
        public static List<ReadTicket> readersTicket { get; set; }
        public ReadersPagee()
        {
            InitializeComponent();
            readersTicket = new List<ReadTicket>(DBConnection.Connection.biblioteka.ReadTicket.
                Where(i => i.Reader.IsDelete == false && i.IsDelete == false).ToList());
            employees = new List<Employee>(DBConnection.Connection.biblioteka.Employee.Where(i => i.IsDelete == false).ToList());
            employees.Insert(0, new Employee() { ID = -1, LastName = " Вывести всех" });
            this.DataContext = this;



        }

        private void TicketSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = TicketSearchTb.Text.Trim();
            if (search == "")
                lstReader.ItemsSource = readersTicket.ToList();
            else
                lstReader.ItemsSource = readersTicket.Where(i => i.IdReader.ToString() == search).ToList();
        }

        private void FiltrEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = FiltrEmployee.SelectedItem as Employee;

            if (t.ID != -1)
                lstReader.ItemsSource = readersTicket.Where(i => i.IdEmployee == t.ID).ToList();
            else
                lstReader.ItemsSource = readersTicket.ToList();
        }

        private void AddReaderTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            Wuindow.AddReaderTicketWindow addReaderTicket = new Wuindow.AddReaderTicketWindow();
            addReaderTicket.Show();
        }
    }
}
