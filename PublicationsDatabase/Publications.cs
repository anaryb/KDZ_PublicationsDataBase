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

        //Author

        

        private int _citedReferences;
        public int CitedReferences
        {
            get { return _citedReferences; }
            set { _citedReferences = value; }
        }

/*        private int _citedReferencesCount;
        public int CitedReferencesCount
        {
            get { return _citedReferencesCount; }
            set { _citedReferencesCount = value; }
        } */

        private int _timesCited;
        public int TimesCited
        {
            get { return _timesCited; }
            set { _timesCited = value; }
        }

        //Publisher 

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

        /* private Authors _auth;
         public Authors Auth
         {
             get { return _auth; }
             set { _auth = value; }
         }*/

        private string _author;
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string Info
        {
            get { return $"{_publicationType} - {_author} - {_title} - {_citedReferences} - {_timesCited}\n{_ISSN_ISBN} - {_publishYear}"; }
        }


        public Publications(string publicationType, string author, string title, int citedReferences, int timesCited, string issn_issbn, int publishYear )
        {
            _publicationType = publicationType;
            _author = author;
            _title = title;
            _citedReferences = citedReferences;
            //_citedReferencesCount = citedReferencesCount;
            _timesCited = timesCited;
            _ISSN_ISBN = issn_issbn;
            _publishYear = publishYear;
            
        }
       
       

    }
}
