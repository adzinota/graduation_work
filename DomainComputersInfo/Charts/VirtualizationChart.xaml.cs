using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace DomainComputersInfo.Charts
{
    public partial class VirtualizationChart : UserControl
    {
        public VirtualizationChart()
        {
            InitializeComponent();

            ChartValues<int> Quantity = new();

            foreach (int i in Logics.StatValues.Virtualization)
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

            Labels = new[] { "Включена", "Отключена" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        //===============================================================================================
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}