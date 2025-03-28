using WpfApp1.DBConnection;
using ControlzEx.Standard;
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


namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class BooksPage : Page
    {
        public static List<Book> books { get; set; }
        public BooksPage()
        {
            InitializeComponent();
            books = new List<Book>(Connection.biblioteka.Book.Where(i => i.IsDelete == false).ToList());
            this.DataContext = this;


        }

        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            Wuindow.AddBookWindo addBookWindow = new Wuindow.AddBookWindo();
            addBookWindow.Show();
        }

        private void SearchTitleTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchTitleTb.Text == "")
                BooksLv.ItemsSource = new List<Book>(Connection.biblioteka.Book.Where(i => i.IsDelete == false).ToList());
            else
                BooksLv.ItemsSource = books.Where(i => i.Name == SearchTitleTb.Text).ToList();
        }

        
    }
}
