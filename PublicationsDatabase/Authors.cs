using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationsDatabase
{

    public class Authors
    {
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


        public Authors(string authorName, string authorJobAdress, string authorEmail)
        {
            _authorName = authorName;
            _authorJobAdress = authorJobAdress;
            _authorEmail = authorEmail;
        }
    }
}
