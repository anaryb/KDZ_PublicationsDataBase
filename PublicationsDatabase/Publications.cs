using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationsDatabase
{

    public class Publications
    {
        private string _publicationType;
        public string PublicationType
        {
            get { return _publicationType; }
            set { _publicationType = value; }
        }
        


        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        

        private int _citedReferences;
        public int CitedReferences
        {
            get { return _citedReferences; }
            set { _citedReferences = value; }
        }



        private int _timesCited;
        public int TimesCited
        {
            get { return _timesCited; }
            set { _timesCited = value; }
        }

        private string _ISSN_ISBN;
        public string ISSN_ISBN
        {
            get { return _ISSN_ISBN; }
            set { _ISSN_ISBN = value; }
        }

        private int _publishYear;
        public int PublishYear
        {
            get { return _publishYear; }
            set { _publishYear = value; }

        }

        private string _publMagazine;
        public string PublMagazine
        {
            get { return _publMagazine; }
            set { _publMagazine = value; }
        }

        private string _authorName;
        public string AuthorName
        {
            get { return _authorName; }
            set { _authorName = value; }
        }

        public string _authorJobAdress;
        public string AuthorAdress
        {
            get { return _authorJobAdress; }
            set { _authorJobAdress = value; }
        }

        public string _authorEmail;
        public string AuthorEmail
        {
            get { return _authorEmail; }
            set { _authorEmail = value; }
        }

        private string _publisher;
        public string Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
        }

        private string _publisherCity;
        public string PublisherCity
        {
            get { return _publisherCity; }
            set { _publisherCity = value; }
        }

        private string _publisherAddress;
        public string PublisherAddress
        {
            get { return _publisherAddress; }
            set { _publisherAddress = value; }
        }

        private int _allpublicationsCount;
        public int AllPublicationsCount
        {
            get { return _allpublicationsCount; }
            set { _allpublicationsCount = value; }
        }

        private int _allTimesCitedCount;
        public int AllTimesCitedCount
        {
            get { return _allTimesCitedCount; }
            set { _allTimesCitedCount = value; }
        }

        private int _pubsPerYear;
        public int PubsPerYear
        {
            get { return _pubsPerYear; }
            set { _pubsPerYear = value; }
        }

        public Publications(int publishYear, int pubsperYear)
        {
            _publishYear = publishYear;
            _pubsPerYear = pubsperYear;
        }

        public Publications(string publicationType, string title, string authorName, int citedReferences, int timesCited, int publishYear, string issn_issbn,  string authorJobAddress, string authorEmail, string publisher, string publisherCity, string publisherAddress, string publMagazine )
        {
            _publicationType = publicationType;
            _title = title;
            _citedReferences = citedReferences;
            _timesCited = timesCited;
            _ISSN_ISBN = issn_issbn;
            _publishYear = publishYear;
            _authorName = authorName;
            _authorJobAdress = authorJobAddress;
            _authorEmail = authorEmail;
            _publisher = publisher;
            _publisherCity = publisherCity;
            _publisherAddress = publisherAddress;
            _publMagazine = publMagazine;
            
        }

       
       

    }
}
