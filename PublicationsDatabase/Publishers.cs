using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationsDatabase
{
   
    public class Publishers
    {
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

        public Publishers(string publisher, string publisherCity, string publisherAddress)
        {
            _publisher = publisher;
            _publisherCity = publisherCity;
            _publisherAddress = publisherAddress;
        }
    }
}
