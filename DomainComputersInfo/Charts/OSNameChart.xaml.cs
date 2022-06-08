using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace DomainComputersInfo.Charts
{
    public partial class OSNameChart : UserControl
    {
        public OSNameChart()
        {
            InitializeComponent();

            ChartValues<int> Quantity = new();

            foreach (int i in Logics.StatValues.OSName)
            {
                Quantity.Add(i);
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "",
                    Values = Quantity
                }
            };

            Labels = new[] { "Windows 7", "Windows 10", "Другие" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        //===============================================================================================
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}