﻿using System;
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
    /// Логика взаимодействия для NewPublicationWindow.xaml
    /// </summary>
    public partial class NewPublicationWindow : Window
    {
        public NewPublicationWindow()
        {
            
            InitializeComponent();
        }

        private void ButAboutAuthor(object sender, RoutedEventArgs e)
        {
            Main.Content = new NewPublAuthor();
        }

        private void ButAboutPubl(object sender, RoutedEventArgs e)
        {
            Main.Content = new NewPublAboutPubl();
        }

        private void ButAboutPublisher(object sender, RoutedEventArgs e)
        {
            Main.Content = new NewPublAboutPublisher();
        }

    }
}
