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
using NLog;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для AllPublicationsPage.xaml
    /// </summary>
    public partial class AllPublicationsPage : Page
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        List<Publications> _pubs = new List<Publications>();
        Publications pub;
        

        List<Authors> _auth = new List<Authors>();
        Authors a;

        List<Publishers> _publish = new List<Publishers>();
        Publishers publishs;
        public AllPublicationsPage()
        {
            InitializeComponent();
            //LoadData();

        }
        
        private void GetPublicationList_Click(object sender, RoutedEventArgs e)
        {

            /*IFormatter formatterPub = new BinaryFormatter();
            Stream streamPub = new FileStream("Publications.bin", FileMode.Open);
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
            _publish.Add(publishs);*/
            LoadData();

            RefreshListView();
            logger.Trace(" ");


        }

        private void SaveDataPublList()
        {

                foreach (Publications publ in _pubs)
                {
                    using (StreamWriter swpub = new StreamWriter("Publications.txt"))
                    {
                        swpub.WriteLine($"{publ.PublicationType}:{publ.Title}:{publ.AuthorName}:{publ.CitedReferences}:{publ.TimesCited}:{publ.PublishYear}:{publ.ISSN_ISBN}:{publ.AuthorAdress}:{publ.AuthorEmail}:{publ.Publisher}:{publ.PublisherCity}:{publ.PublisherAddress}");
                    }
                }
        }

        private void LoadData()
        {
            try
            {
                using (var sr = new StreamReader("Publications.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();

                            if (line == "")
                            {
                                MessageBox.Show("Пожалуйста добавьте публикацию");
                                NavigationService.Navigate(Pages.NewPublAboutAuthor);
                            }
                            var parts = line.Split(':');
                            if (parts.Length == 12)
                            {
                                Publications p = new Publications(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), parts[6], parts[7], parts[8], parts[9], parts[10], parts[11]);
                                _pubs.Add(p);

                            }
                    }
                }
            }
            catch (FileNotFoundException )
            {
                MessageBox.Show("Файл с публикациями не существует. Пожалуйста добавьте публикацию");
                NavigationService.Navigate(Pages.NewPublAboutAuthor);
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }
            
        }

        private void AddNewP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.NewPublAboutAuthor);
        }

        private void DeletePublicationList_Click(object sender, RoutedEventArgs e)
        {
            _pubs.Remove((Publications)publicationsList.SelectedItem);
            SaveDataPublList();
            RefreshListView();


        }

        public void RefreshListView()
        {
            publicationsList.ItemsSource = null;
            publicationsList.ItemsSource = _pubs;
        }

        private void buttonSaveChangedInfo_Click(object sender, RoutedEventArgs e)
        {
            SaveDataPublList();
            MessageBox.Show("Ваши данные успешно изменены!");
        }
    }
}
