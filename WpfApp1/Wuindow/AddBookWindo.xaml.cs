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
    /// Логика взаимодействия для AddBookWindo.xaml
    /// </summary>
    public partial class AddBookWindo
    {
        public static List<Author> authors { get; set; }
        public static List<CreateBuild> builds { get; set; }
        public static List<Janr> janrs { get; set; }
        public static List<Hall> halls { get; set; }
        public AddBookWindo()
        {
            InitializeComponent();
            authors = new List<Author>(Connection.biblioteka.Author.ToList());
            builds = new List<CreateBuild>(Connection.biblioteka.CreateBuild.ToList());
            janrs = new List<Janr>(Connection.biblioteka.Janr.ToList());
            halls = new List<Hall>(Connection.biblioteka.Hall.ToList());
            this.DataContext = this;
        }
        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            if (TitleTb.Text != null && AuthorCm.SelectedItem != null &&
                CreatorBuildCm.SelectedItem != null && JanrCm.SelectedItem != null &&
                HallCm.SelectedItem != null && ShelfTb.Text != null && DateMadeDp.SelectedDate != null &&
                   CountPagesTb.Text != null)
            {
                book.Name = TitleTb.Text.Trim();
                book.IdAuthor = (AuthorCm.SelectedItem as Author).ID;
                book.IdCreateBuild = (CreatorBuildCm.SelectedItem as CreateBuild).ID;
                book.IdJanr = (JanrCm.SelectedItem as Janr).ID;
                book.IdHall = (HallCm.SelectedItem as Hall).ID;
                book.Shelf = Convert.ToInt32(ShelfTb.Text.Trim());
                MessageBox.Show("Такой полки нет");
                book.YearMade = DateMadeDp.SelectedDate;
                book.CountPage = Convert.ToInt32(CountPagesTb.Text.Trim());
                book.IsDelete = false;
                Connection.biblioteka.Book.Add(book);
                Connection.biblioteka.SaveChanges();
                MessageBox.Show("Книга успешно добавлена");
                Close();
            }
        }

        private void ShelfTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (HallCm.SelectedItem != null)
            {
                if (Convert.ToInt32(ShelfTb.Text) >= (HallCm.SelectedItem as Hall).CountShelf)
                    MessageBox.Show("Такой полки нет");
            }
            else
            {
                MessageBox.Show("Для начала выберите зал!");
            }
        }

        private void AddAuthorBtn_Click(object sender, RoutedEventArgs e)
        {
            AddAuthorWindo addAuthorWindow = new AddAuthorWindo();
            addAuthorWindow.Show();

        }

        private void UpdateBookBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorCm.ItemsSource = new List<Author>(Connection.biblioteka.Author.ToList());
        }
    }
}
