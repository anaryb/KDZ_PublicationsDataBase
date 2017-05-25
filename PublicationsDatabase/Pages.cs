using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationsDatabase
{
    static class Pages
    {
        private static RegistrationPage _registrationPage = new RegistrationPage();
        public static RegistrationPage RegistrationPage
        {
            get
            {
                return _registrationPage;
            }
        }

        private static AuthPage _authPage = new AuthPage();
        public static AuthPage AuthPage
        {
            get { return _authPage; }
        }

        private static NewPublAboutAuthor _newPublAboutAuthor = new NewPublAboutAuthor();
        public static NewPublAboutAuthor NewPublAboutAuthor
        {
            get { return _newPublAboutAuthor; }
        }

        private static NewPublAboutPubl _newPublAboutPubl = new NewPublAboutPubl();
        public static NewPublAboutPubl NewPublAboutPubl
        {
           get { return _newPublAboutPubl; }
        }

        private static NewPublAboutPublisher _newPublAboutPublisher = new NewPublAboutPublisher();
        public static NewPublAboutPublisher NewPublAboutPublisher
        {
            get { return _newPublAboutPublisher; }
        }

        private static MainDatabasePage _mainDatabasePage = new MainDatabasePage();
        public static MainDatabasePage MainDatabasePage
        {
            get { return _mainDatabasePage; }
        }

        private static AllPublicationsPage _allPublicationsPage = new AllPublicationsPage();
        public static AllPublicationsPage AllPublicationsPage
        {
            get { return _allPublicationsPage; }
        }


        private static StatisticsPage _statisticsPage = new StatisticsPage(Pages.AllPublicationsPage.TakePub);
        public static StatisticsPage StatisticsPage
        {
            get { return _statisticsPage; }
            set { _statisticsPage = value; }
        }

    }
}
