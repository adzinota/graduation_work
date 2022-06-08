using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow()
        {
            InitializeComponent();
            Statistics.GetFromDB();
        }

        //===============================================================================================
        private void Processor_Click(object sender, RoutedEventArgs e)
        {
            Charts.ProcessorChartWindow processorChartWindow = new();
            processorChartWindow.Show();
        }

        //===============================================================================================

        private void Memory_Click(object sender, RoutedEventArgs e)
        {
            Charts.MemoryChartWindow memoryChartWindow = new();
            memoryChartWindow.Show();
        }

        //===============================================================================================
        private void OS_Click(object sender, RoutedEventArgs e)
        {
            Charts.OSChartWindow oSChartWindow = new();
            oSChartWindow.Show();
        }
    }
}
