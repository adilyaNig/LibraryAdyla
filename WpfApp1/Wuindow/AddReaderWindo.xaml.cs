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
using System.Windows.Shapes;
using WpfApp1.DBConnection;

namespace WpfApp1.Wuindow
{
    /// <summary>
    /// Логика взаимодействия для AddReaderWindo.xaml
    /// </summary>
    public partial class AddReaderWindo
    {
        public AddReaderWindo()
        {
            InitializeComponent();
        }
        private void SaveReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            Reader reader = new Reader();
            reader.LastName = LastNameTb.Text.Trim();
            reader.Name = NameTb.Text.Trim();
            reader.Patronymic = PatromymicTb.Text.Trim();
            reader.Birthdate = BirthDateDp.SelectedDate;
            reader.Phone = PhoneTb.Text.Trim();
            reader.IsDelete = false;
            Connection.biblioteka.Reader.Add(reader);
            Connection.biblioteka.SaveChanges();
            MessageBox.Show("Читатель успешно добавлен.");
            Close();
        }
    }
}
