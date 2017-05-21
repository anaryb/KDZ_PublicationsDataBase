using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.IO;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        List<Users> _users = new List<Users>();
        public AuthPage()
        {
            InitializeComponent();
            LoadData();
        }


        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        private void LoadData()
        {

            using (var sr = new StreamReader("users.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        Users u;
                        u = new Users(parts[0], parts[1]);
                        _users.Add(u);
                    }
                }
            }
        }

        private void LoginUser_Click(object sender, RoutedEventArgs e)
        {
            foreach (var user in _users)
            {
                
                if ((Userlogin.Text == user.UserName) && (CalculateHash(UserPassword.Text) == user.UserPassword))
                {
                    var w = new MainDatabaseWindow();
                    w.Show();                    
                }
                else
                {
                    Userlogin.Clear();
                    UserPassword.Clear();
                    MessageBox.Show("Неправильно введены имя пользователя или пароль");
                }
                    
            }

            


           

            
        }
    }
}
