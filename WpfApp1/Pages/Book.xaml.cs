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
    /// Логика взаимодействия для Book.xaml
    /// </summary>
    public partial class Book : Page
    {
        public static List<Book> books { get; set; }
        public static List<Author> authors { get; set; }
        public Book()
        {
            InitializeComponent();
          

               
        }


        private void BookSearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void FilterrB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
      
        }
    }
}
