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


        private void ButtonClickAllPublPage(object sender, RoutedEventArgs e)
        {
            Main.Content = new AllPublicationsPage();
        }

        private void ButtonClickAddNewPubl(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewPublicationWindow newpubl = new NewPublicationWindow();
            newpubl.Show();
          
        }




    }
}
