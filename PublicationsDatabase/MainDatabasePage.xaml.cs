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

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для MainDatabasePage.xaml
    /// </summary>
    public partial class MainDatabasePage : Page
    {
        public MainDatabasePage()
        {
            InitializeComponent();
        }

        private void ButtonAllPublications_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AllPublicationsPage);
        }

        private void ButtonAddPublication_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.NewPublAboutAuthor);
        }
    }
}
