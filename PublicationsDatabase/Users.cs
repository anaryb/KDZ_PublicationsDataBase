using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicationsDatabase
{
    class Users
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
        }

        private string _userPassword;
        public string UserPassword
        {
            get { return _userPassword; }
        }
        public Users(string UserName, string UserPassword)
        {
            _userName = UserName;
            _userPassword = UserPassword;
        }


    }
}