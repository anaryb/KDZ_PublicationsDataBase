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
        public List<Publications> TakePub
        {
            get { return _pubs; }
        }
        List<Publications> _pubsPerYear = new List<Publications>();

        List<Authors> _auth = new List<Authors>();

        List<Publishers> _publish = new List<Publishers>();

        public int allPublCount = 0;
        public int allTimesCitedCount = 0;
        public double timescitedperpubl;


        string searchI;
        public AllPublicationsPage()
        {
            InitializeComponent();

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

            logger.Trace("Получен список публикаций из файла Publications.txt");


        }

        private void SaveDataPublList()
        {
            using (FileStream fs = new FileStream("Publications.txt", FileMode.Create))
            {
                using (StreamWriter swpub = new StreamWriter(fs))
                { 
                    foreach (Publications publ in _pubs)
                    {
                        swpub.WriteLine($"{publ.PublicationType}^{publ.Title}^{publ.AuthorName}^{publ.CitedReferences}^{publ.TimesCited}^{publ.PublishYear}^{publ.ISSN_ISBN}^{publ.AuthorAdress}^{publ.AuthorEmail}^{publ.Publisher}^{publ.PublisherCity}^{publ.PublisherAddress}^{publ.PublMagazine}");
                    }
                }
            }
            logger.Trace("Информация в текстовом документе сохранена!");

        }

        private void LoadData()
        {
            try
            {
                _pubs = new List<Publications>();
                

                using (FileStream fs = new FileStream("Publications.txt", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            var parts = line.Split('^');
                            if (parts.Length == 13)
                            {
                                Publications p = new Publications(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12]);

                                _pubs.Add(p);
                            }
                          
                            
                        }
                        sr.Close();
                    }
                    fs.Close();
                }


            }
            catch (FileNotFoundException )
            {
                MessageBox.Show("Файл с публикациями не существует. Пожалуйста добавьте публикацию");
                logger.Warn("Файла с данными не существует!");
                NavigationService.Navigate(Pages.NewPublAboutAuthor);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                logger.Fatal(ex.Message);
            }
            


        }

        private void AddNewP_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.NewPublAboutAuthor);
        }

        private void DeletePublicationList_Click(object sender, RoutedEventArgs e)
        {
            List<Publications> _pubsDel = new List<Publications>();
            foreach (Publications p in _pubs)
            {
                _pubsDel.Add(p);
            }
            _pubsDel.Remove((Publications)publicationsList.SelectedItem);

            _pubs.Clear();

            foreach (Publications pub in _pubsDel )
            {
                _pubs.Add(pub);
            }
            _pubsDel.Clear();

            MessageBox.Show("Выбранная публикация успешно удалена из базы данных!");
            RefreshListView();
            SaveDataPublList();
            logger.Trace("Публикация удалена");

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


        public void dataSearchInfo(string searchInfo)
        {
            searchI = searchInfo;
            List<Publications> _pubsSearch = new List<Publications>();

            try
            {
                using (FileStream fs = new FileStream("Publications.txt", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();

                            if (line == "")
                            {
                                MessageBox.Show("Пожалуйста нет ни одной публикации. Перенаправление на добавление новой публикации");
                                NavigationService.Navigate(Pages.NewPublAboutAuthor);
                            }
                            var parts = line.Split('^');
                            if (parts.Length == 13)
                            {
                                for (int i = 0; i < parts.Length; i++)
                                {
                                    if ((parts[i].Contains(searchI) == true))
                                    {
                                        Publications p = new Publications(parts[0], parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12]);
                                        _pubsSearch.Add(p);
                                        break;
                                    }
                                    
                                }
                            }
                        }

                        sr.Close();
                    }
                    fs.Close();
                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл с публикациями не существует. Пожалуйста добавьте публикацию");
                NavigationService.Navigate(Pages.NewPublAboutAuthor);
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }

            publicationsList.ItemsSource = null;
            publicationsList.ItemsSource = _pubsSearch;

        }

        private void SearchPublication_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchWindow();
            window.Show();
        }

        public void NewPublAdded(Publications publ)
        {
            _pubs.Add(publ);
        }

        private void GetStatistics_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                timescitedperpubl = (1.0 * allTimesCitedCount / allPublCount);
                Pages.StatisticsPage.AllPubltextBox.Text = allPublCount.ToString();
                Pages.StatisticsPage.AllTimesCited.Text = allTimesCitedCount.ToString();
                Pages.StatisticsPage.TimesCitedPerPubl.Text = timescitedperpubl.ToString();





                var window = new StatisticsWindow();
                window.Show();
                window.StatWindowFrame.Navigate(new StatisticsPage(_pubs));
                allPublCount = 0;
                allTimesCitedCount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
