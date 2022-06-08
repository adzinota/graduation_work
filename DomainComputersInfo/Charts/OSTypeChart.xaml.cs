using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace DomainComputersInfo.Charts
{
    public partial class OSTypeChart : UserControl
    {
        public OSTypeChart()
        {
            InitializeComponent();

            ChartValues<int> Quantity = new();

            foreach (int i in Logics.StatValues.OSType)
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

            Labels = new[] { "Профессиональная", "Корпоративная", "Другие" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        //===============================================================================================
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}