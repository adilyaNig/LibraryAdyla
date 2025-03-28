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
    /// Логика взаимодействия для AddAuthorWindo.xaml
    /// </summary>
    public partial class AddAuthorWindo
    {
        public AddAuthorWindo()
        {
            InitializeComponent();
        }
        private void SaveAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            Author author = new Author();
            if (LastNameTb.Text != null && NameTb.Text != null && PatronymicTb.Text != null)
            {
                author.LastName = LastNameTb.Text;
                author.Name = NameTb.Text;
                author.Patronymic = PatronymicTb.Text;
                Connection.biblioteka.Author.Add(author);
                Connection.biblioteka.SaveChanges();
                MessageBox.Show("Автор успешно сохранен");
                Close();
            }
        }
    }
}
