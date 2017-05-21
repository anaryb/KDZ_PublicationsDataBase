using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для NewPublAboutPubl.xaml
    /// </summary>
    public partial class NewPublAboutPubl : Page
    {
        const string FileName = "Publications.txt";
        Publications _publication;
        List<Publications> _publications = new List<Publications>();

        Authors _auth;
        List<Authors> _authors = new List<Authors>();

        Publishers _publish;
        List<Publishers> _publishers = new List<Publishers>();
        public NewPublAboutPubl()
        {
            InitializeComponent();
            comboBoxPublicationType.Focus();
        }

        private void AddOverallPublication_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTitle.Text))
            {
                MessageBox.Show("Необходимо ввести азвание");
                textBoxTitle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCitedReferences.Text))
            {
                MessageBox.Show("Необходимо ввести количество ссылок");
                textBoxCitedReferences.Focus();
                return;
            }
            int CitedReferences;
            if (!int.TryParse(textBoxCitedReferences.Text, out CitedReferences) || (CitedReferences <0))
            {
                MessageBox.Show("Некорректное значение рейтинга");
                textBoxCitedReferences.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(textBoxTimesCited.Text))
            {
                MessageBox.Show("Необходимо ввести сколько раз ссылались");
                textBoxTimesCited.Focus();
                return;
            }

            int TimesCited;
            if ((!int.TryParse(textBoxTimesCited.Text, out TimesCited)) || (TimesCited <0 ))
            {
                MessageBox.Show("Некорректное значение сколько раз ссылались");
                textBoxTimesCited.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(textBoxISSN_ISBN.Text))
            {
                MessageBox.Show("Необходимо ввести ISSN/ISBN");
                textBoxISSN_ISBN.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDOI.Text))
            {
                MessageBox.Show("Необходимо ввести DOI");
                textBoxDOI.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxPublishYear.Text))
            {
                MessageBox.Show("Необходимо ввести год издания");
                textBoxPublishYear.Focus();
                return;
            }

            int PublishYear;
            if ((!int.TryParse(textBoxPublishYear.Text, out PublishYear)) || (PublishYear > 2017)) 
            {
                MessageBox.Show("Некорректное значение года издания");
                textBoxPublishYear.Focus();
                return;
            }

            if (comboBoxPublicationType.SelectedItem == null)
            {
                MessageBox.Show("Некорректный выбор типа публикации");
                comboBoxPublicationType.Focus();
                return;
            }

            foreach (Authors a in _authors)
            {
                _auth = a;
            }

            foreach (Publishers p in _publishers)
            {
                _publish = p;

            }


            _publication = new Publications(comboBoxPublicationType.Text, textBoxTitle.Text, _auth.AuthorName, CitedReferences, TimesCited, PublishYear, textBoxISSN_ISBN.Text, _auth.AuthorAdress, _auth.AuthorEmail, _publish.Publisher, _publish.PublisherCity, _publish.PublisherAddress);
            _publications.Add(_publication); 
            SaveDataPubl();

            NavigationService.Navigate(Pages.MainDatabasePage);

        }
        private void SaveDataPubl()
        {
            using (FileStream fs = new FileStream("Publications.txt", FileMode.Append))
            {
                foreach (Publications publ in _publications)
                {
                    using (StreamWriter swpub = new StreamWriter(fs))
                    {
                        swpub.WriteLine($"{publ.PublicationType}:{publ.Title}:{publ.AuthorName}:{publ.CitedReferences}:{publ.TimesCited}:{publ.PublishYear}:{publ.ISSN_ISBN}:{publ.AuthorAdress}:{publ.AuthorEmail}:{publ.Publisher}:{publ.PublisherCity}:{publ.PublisherAddress}");
                    }
                }
                
            }

            
            /*IFormatter formatterPublic = new BinaryFormatter();
            using (FileStream streamPublic = new FileStream("Publications.bin", FileMode.Append))
            {
                foreach (Publications publ in _publications)
                {
                    formatterPublic.Serialize(streamPublic, publ);
                }
                streamPublic.Close();
            }



            IFormatter formatterAuth = new BinaryFormatter();
            Stream streamAuth = new FileStream("Authors.bin", FileMode.Append, FileAccess.Write, FileShare.None);
            formatterAuth.Serialize(streamAuth, _auth );
            streamAuth.Close();

            IFormatter formatterPublisher = new BinaryFormatter();
            Stream streamPublisher = new FileStream("Publishers.bin", FileMode.Append, FileAccess.Write, FileShare.None);
            formatterPublisher.Serialize(streamPublisher, _publish);
            streamPublisher.Close();
            */
        }

        public void NewAuthorAdded(Authors auth)
        {
            _authors.Add(auth);
        }

        public void NewPublisherAdded(Publishers publish)
        {
            _publishers.Add(publish);
        }


    }
}
