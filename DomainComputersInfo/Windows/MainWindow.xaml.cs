using System.Windows;

namespace DomainComputersInfo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //===============================================================================================
        private void Database_Click(object sender, RoutedEventArgs e)
        {
            Windows.DatabaseWindow databaseWindow = new();
            databaseWindow.Show();
        }

        //===============================================================================================
        private void CommonInfo_Click(object sender, RoutedEventArgs e)
        {
            Windows.CommonInfoWindow commonInfoWindow = new();
            commonInfoWindow.Show();
        }

        //===============================================================================================
        private void Statistics_Click(object sender, RoutedEventArgs e)
        {
            Windows.StatisticsWindow statisticsWindow = new();
            statisticsWindow.Show();
        }

        //===============================================================================================
        private void DetailedInfo_Click(object sender, RoutedEventArgs e)
        {
            Windows.DetailedInfoWindow detailedInfoWindow = new();
            detailedInfoWindow.Show();
        }
    }
}