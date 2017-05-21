using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationsDatabase
{
    [Serializable]
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

        private Authors _author;
        public Authors Author
        {
            get { return _author; }
            set { _author = value; }
        }

        private Publishers _publisher;
        public Publishers Publisher
        {
            get { return _publisher; }
            set { _publisher = value; }
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


        public Publications(string publicationType, string title, int citedReferences, int timesCited, string issn_issbn, int publishYear )
        {
            _publicationType = publicationType;
            _title = title;
            _citedReferences = citedReferences;
            _timesCited = timesCited;
            _ISSN_ISBN = issn_issbn;
            _publishYear = publishYear;
            
        }

       
       

    }
}
