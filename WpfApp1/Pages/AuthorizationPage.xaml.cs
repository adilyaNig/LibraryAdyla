﻿using System;
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
using WpfApp1.Window;
using WpfApp1.DBConnection;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage:Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            Emploe emploe = new Emploe();
            emploe.Show();

        }

        private void loginReaderBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReadersPagee());
        }
    }
}
