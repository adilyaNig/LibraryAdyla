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
using WpfApp1.Pages;
using WpfApp1.Window;
using WpfApp1.Wuindow;

namespace WpfApp1.Wuindow
{
    /// <summary>
    /// Логика взаимодействия для AddReaderTicketWindow.xaml
    /// </summary>
    public partial class AddReaderTicketWindow
    {
        public static List<Reader> readers {  get; set; }
        public static List<Employee> employees {  get; set; }


        public AddReaderTicketWindow()
        {
            InitializeComponent();
            readers = new List<Reader>(Connection.biblioteka.Reader.Where(i=>i.IsDelete == false).ToList());
            employees = new List<Employee>(Connection.biblioteka.Employee.Where(i=>i.IsDelete == false).ToList());
            this.DataContext = this;
        }

        private void SaveTicketBtn_Click(object sender, RoutedEventArgs e)
        {
           ReadTicket readTicket= new ReadTicket();
            readTicket.IsDelete=false;
            readTicket.DateRegistr=DateTime.Now;
            var reader =ReaderCm.SelectedItem as Reader;
            readTicket.IdReader = reader.ID;
            var employee= EmployeeCm.SelectedItem as Employee;
            readTicket.IdEmployee = employee.ID;
            Connection.biblioteka.ReadTicket.Add(readTicket);
            Connection.biblioteka.SaveChanges();
            MessageBox.Show("Новый билет добавлен.");
            Close();
        }

        private void ReaderCm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EmployeeCm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeTicketWindow emploe = new AddEmployeeTicketWindow();
            emploe.Show();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ReaderCm.ItemsSource=new List<Reader>(Connection.biblioteka.Reader.Where(i=>i.IsDelete
            ==false).ToList());
        }
    }
}
