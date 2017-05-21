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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для AllPublicationsPage.xaml
    /// </summary>
    public partial class AllPublicationsPage : Page
    {
        List<Publications> _pubs = new List<Publications>();
        Publications pub;

        List<Authors> _auth = new List<Authors>();
        Authors a;

        List<Publishers> _publish = new List<Publishers>();
        Publishers publishs;
        public AllPublicationsPage()
        {
            InitializeComponent();
        }
        
        private void GetPublicationList_Click(object sender, RoutedEventArgs e)
        {
             IFormatter formatterPub = new BinaryFormatter();
             Stream streamPub = new FileStream("Publications.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
             Publications objPub = (Publications)formatterPub.Deserialize(streamPub);
             streamPub.Close();
             pub = objPub;
             _pubs.Add(pub);

            IFormatter formatterAuth = new BinaryFormatter();
            Stream streamAuth = new FileStream("Authors.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Authors objAuth = (Authors)formatterAuth.Deserialize(streamAuth);
            streamAuth.Close();
            a = objAuth;
            _auth.Add(a);

            IFormatter formatterPublish = new BinaryFormatter();
            Stream streamPublish = new FileStream("Publishers.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Publishers objPublish = (Publishers)formatterAuth.Deserialize(streamPublish);
            streamPublish.Close();
            publishs = objPublish;
            _publish.Add(publishs);




        }


        private void AddNewP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.NewPublAboutAuthor);
        }

        private void DeletePublicationList_Click(object sender, RoutedEventArgs e)
        {
            _pubs.Remove((Publications)publicationsList.SelectedItem);
            publicationsList.ItemsSource = null;
            publicationsList.ItemsSource = _pubs;

        }
    }
}
