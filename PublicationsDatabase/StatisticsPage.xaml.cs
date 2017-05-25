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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PublicationsDatabase
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        int publcount;
        int timescitedcount;
        List<Publications> _pubsInfo = new List<Publications>();

        public StatisticsPage(List<Publications> Workl)
        {
            InitializeComponent();
           
            int publ = Workl.Count;
            AllPubltextBox.Text = Workl.Count.ToString();
            int alltime = 0;

            
            /*
            AllPubltextBox.Text = allPublCount;
            AllTimesCited.Text = allTimesCited;
            TimesCitedPerPubl.Text = TCperP;
            */

            AllPubltextBox.IsReadOnly = true;
            AllTimesCited.IsReadOnly = true;
            TimesCitedPerPubl.IsReadOnly = true;
            foreach (Publications p in Workl)
            {
                alltime += p.TimesCited;
                _pubsInfo.Add(p);
            }
            AllTimesCited.Text = alltime.ToString();
            double citeperp = 0;
            if (alltime != 0) citeperp = (double)alltime/ (double)publ;
            else citeperp = 0;
            TimesCitedPerPubl.Text=citeperp.ToString();

            //      MessageBox.Show(_pubsInfo.Count.ToString());



        }

        public void AllPublCount(int pc)
        {
            publcount = pc;
        }

        public void TimesCitedCount(int tc)
        {
            timescitedcount = tc;
        }

        public class Stats
        {
            public int year;
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            public int Count
            {
                get { return count; }
                set { count = value; }
            }
            public int count;
            public Stats (int y, int c)
            {
                year = y;
                count = c;
            }
            public void Grow()
            {
                count++;
            }

        }
        private void buttonYearInfo_Click(object sender, RoutedEventArgs e)
        {
            int countyear = 0;
            _pubsInfo.Sort((pub1, pub2) => pub1.PublishYear.CompareTo(pub2.PublishYear));
            List<Stats> PubCount=new List<Stats>();
            var YearGroups = from pub in _pubsInfo
                             group pub by pub.PublishYear;
            int i = 0;
            foreach (IGrouping<int, Publications> g in YearGroups)
            {
                
                try
                {
                    PubCount.Add(new Stats((int)g.Key, 0));
                    foreach (var t in g)
                    {
                        PubCount[i].Grow();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                i++;
            }
           
            StatisticsList.ItemsSource = null;
            StatisticsList.ItemsSource = PubCount;
        }
    }
}
