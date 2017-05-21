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
    /// Логика взаимодействия для NewPublAuthor.xaml
    /// </summary>
    public partial class NewPublAboutAuthor : Page
    {
        List<Authors> _authors = new List<Authors>();
        Authors _author;
        public NewPublAboutAuthor()
        {
            InitializeComponent();
            authorName.Focus();
        }

        private void AuthorPublNext_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(authorName.Text))
            {
                MessageBox.Show("Необходимо ввести ФИО Автора");
                authorName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(JobAddress.Text))
            {
                MessageBox.Show("Необходимо ввести место работы");
                JobAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(AuthEmail.Text))
            {
                MessageBox.Show("Необходимо ввести электронную почту");
                AuthEmail.Focus();
                return;
            }
             _author = new Authors(authorName.Text, JobAddress.Text, AuthEmail.Text);
            Pages.NewPublAboutPubl.NewAuthorAdded(_author);

            NavigationService.Navigate(Pages.NewPublAboutPublisher);
        }



    }
}
