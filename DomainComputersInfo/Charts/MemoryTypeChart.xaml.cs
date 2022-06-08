using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace DomainComputersInfo.Charts
{
    public partial class MemoryTypeChart : UserControl
    {
        public MemoryTypeChart()
        {
            InitializeComponent();

            ChartValues<int> Quantity = new();

            foreach (int i in Logics.StatValues.MemoryType)
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

            Labels = new[] { "DDR3", "DDR4", "Другие" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        //===============================================================================================
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}