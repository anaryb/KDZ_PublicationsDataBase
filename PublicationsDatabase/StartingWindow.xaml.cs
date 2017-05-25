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
        public int guestflag = 0;
        public StartingWindow()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new RegAuthWindow();
                window.Show();
                window.Main.Navigate(new RegistrationPage());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void buttonAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new RegAuthWindow();
                window.Show();
                window.Main.Navigate(new AuthPage());
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonGuest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                guestflag = 1;

                var window = new MainDatabaseWindow();
                Pages.MainDatabasePage.GuestFunc(guestflag);
                window.Show();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void buttonGuest_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonGuest.FontSize = 16;
        }

        private void buttonGuest_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonGuest.FontSize = 14;
        }

        private void buttonReg_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonReg.FontSize = 16;
        }

        private void buttonReg_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonReg.FontSize = 14;
        }

        private void buttonAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonAuth.FontSize = 16;
        }

        private void buttonAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonAuth.FontSize = 14;
        }
    }
}
