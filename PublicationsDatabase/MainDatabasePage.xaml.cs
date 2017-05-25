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
        int guestflag = 0;
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


        public void GuestFunc(int gf)
        {
            guestflag = gf;
            if (guestflag == 1)
            {
                MessageBox.Show("Вы не авторизовались, поэтому не cможете добавлять и изменять данные!");
                this.ButtonAddPublication.IsEnabled = false;

                Pages.AllPublicationsPage.AddNewP.IsEnabled = false;
                Pages.AllPublicationsPage.DeletePublicationList.IsEnabled = false;
                Pages.AllPublicationsPage.AuthorAdressEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.AuthorEmailEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.AuthorNameEdit.IsReadOnly = true;

                Pages.AllPublicationsPage.PublisherEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.PublisherCityEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.PublisherAddressEdit.IsReadOnly = true;

                Pages.AllPublicationsPage.PublicationTypeEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.TitleEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.CitedReferencesEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.TimesCitedEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.ISSN_ISBNEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.PublishYearEdit.IsReadOnly = true;
                Pages.AllPublicationsPage.PublMagazineEdit.IsReadOnly = true;

                Pages.AllPublicationsPage.buttonSaveChangedInfo.IsEnabled = false;
                Pages.AllPublicationsPage.buttonSaveChangedInfo2.IsEnabled = false;


            }
        }
    }
}
