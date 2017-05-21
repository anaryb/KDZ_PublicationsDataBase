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
    /// Логика взаимодействия для NewPublAboutPublisher.xaml
    /// </summary>
    public partial class NewPublAboutPublisher : Page
    {
        const string FileName = "Publications.txt";
        List<Publishers> _publishers = new List<Publishers>();
        public NewPublAboutPublisher()
        {
            InitializeComponent();
            textBoxPublisher.Focus();
        }

        private void NewPublPublisherNext_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPublisher.Text))
            {
                MessageBox.Show("Необходимо ввести название издательства");
                textBoxPublisher.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPublisherAddress.Text))
            {
                MessageBox.Show("Необходимо ввести адрес издательства");
                textBoxPublisherAddress.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPublisherCity.Text))
            {
                MessageBox.Show("Необходимо ввести город издательства");
                textBoxPublisherCity.Focus();
                return;
            }
            Publishers _publisher = new Publishers(textBoxPublisher.Text, textBoxPublisherCity.Text, textBoxPublisherAddress.Text);
            Pages.NewPublAboutPubl.NewPublisherAdded(_publisher);

            NavigationService.Navigate(Pages.NewPublAboutPubl);
        }
    }
}
