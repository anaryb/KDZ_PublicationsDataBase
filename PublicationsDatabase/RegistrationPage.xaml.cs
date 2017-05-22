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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        const string FileName = "users.txt";
        List<Users> _users = new List<Users>();

        public RegistrationPage()
        {
            InitializeComponent();
            LoadData();
            
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewUserlogin.Text))
            {
                MessageBox.Show("Необходимо ввести Ваш Логин");
                NewUserlogin.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(NewUserPassword.Text))
            {
                MessageBox.Show("Необходимо ввести Пароль");
                NewUserPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(NewUserPasswordConfirm.Text))
            {
                MessageBox.Show("Необходимо подтвердить пароль");
                NewUserPasswordConfirm.Focus();
                return;
            }

            if (NewUserPassword.Text != NewUserPasswordConfirm.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                NewUserPassword.Focus();
                return;
            }

            foreach (var us in _users)
            {
                if (NewUserlogin.Text == us.UserName)
                {
                    MessageBox.Show("Такой пользователь уже существует");
                    NewUserlogin.Focus();
                    return;
                }
            }

            Users user = new Users(NewUserlogin.Text, NewUserPassword.Text);
            _users.Add(user);

            SaveData();
            MessageBox.Show("Вы успешно зарегистрировались!");
            
    
            
        }

        private string CalculateHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return Convert.ToBase64String(hash);
        }


        private void SaveData()
        {
            foreach (var user in _users)
            {
                using (StreamWriter sw = new StreamWriter(FileName))
                {
                    var hash = CalculateHash(user.UserPassword);
                    //Сдлать так, чтобы при каждом новом заходе в программу добавлялись новые пароли и юзеры
                    sw.WriteLine($"{user.UserName}:{hash}");
                }
            }
        }


        private void LoadData()
        {
            try
            {
                
                using (StreamReader sr = new StreamReader(FileName))
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
                // Файла с данными нет, создаем обычный пароль и логин
                _users.Add(new Users("NastyaAdmin", "admin"));
            }
        }

           
        }


    }
