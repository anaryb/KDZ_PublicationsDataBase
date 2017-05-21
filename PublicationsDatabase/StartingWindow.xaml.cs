using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для StartingWindow.xaml
    /// </summary>
    public partial class StartingWindow : Window
    {
        public StartingWindow()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            var window =  new RegAuthWindow();
            window.Show();
            window.Main.Navigate(new RegistrationPage());
            this.Close();


        }

        private void buttonAuth_Click(object sender, RoutedEventArgs e)
        {
            
            var window = new RegAuthWindow();
            window.Show();
            window.Main.Navigate(new AuthPage());
            this.Close();            
        }
    }
}
