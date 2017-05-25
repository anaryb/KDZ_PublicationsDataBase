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
using NLog;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        List<Users> _users = new List<Users>();
        Logger logger = LogManager.GetCurrentClassLogger();
        int i;

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
            try
            {
                using (StreamReader sr = new StreamReader("users.txt"))
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
            catch (FileNotFoundException)
            {
                // Файла с данными нет
                MessageBox.Show("Еще ни одного пользователя не зарегистрировано! \nПожалуйста зарегистрируйтесь!");
                logger.Warn("Нет файла users.txt для чтения. Перенаправление на регистрацию");
                

            }
            catch (Exception exc)
            {
                logger.Fatal(exc.ToString());
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
                    logger.Info("Произведен вход пользователя {0}", user.UserName);
                    i = 1;
                }                    
            }
            if (i == 0)
                MessageBox.Show("Неправильно введен логин/пароль");

            Pages.MainDatabasePage.GuestFunc(0);
            
        }
    }
}
