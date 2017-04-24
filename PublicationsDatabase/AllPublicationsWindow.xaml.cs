using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для AllPublicationsWindow.xaml
    /// </summary>
    public partial class AllPublicationsWindow : Window
    {

        /*const string FileName = "Publications.txt";
        List<Publication> _publications = new List<Publication>();
        List<Authors> _authors = new List<Authors>();*/

        List<Publications> _publications = new List<Publications>();
        public AllPublicationsWindow()
        {
            InitializeComponent();
            _publications.Add(new Publications("J - Journal", "asdasd", "sdfsdfsf", 6, 7, "5667", 2016));
            RefreshListBox();
        }


        private void RefreshListBox() //обновляет список публикаций
        {
            listBoxPublications.ItemsSource = null;
            listBoxPublications.ItemsSource = _publications;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewPublicationWindow();
            if (window.ShowDialog().Value)
            {
                _publications.Add(window.NewPublication);
                RefreshListBox();
            }
        }


        private void listBoxPublications_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonDelete.IsEnabled = listBoxPublications.SelectedIndex != -1;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxPublications.SelectedIndex != -1)
            {
                _publications.RemoveAt(listBoxPublications.SelectedIndex);
                RefreshListBox();
            }
        }
    }
}
