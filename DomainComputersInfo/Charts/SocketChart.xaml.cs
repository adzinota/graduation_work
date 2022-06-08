using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Windows.Controls;

namespace DomainComputersInfo.Charts
{
    public partial class SocketChart : UserControl
    {
        public SocketChart()
        {
            InitializeComponent();

            ChartValues<int> Quantity = new();

            foreach (int i in Logics.StatValues.Socket)
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

            Labels = new[] { "LGA 1156", "LGA 1155", "LGA 1150", "LGA 1151", "Другие" };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        //===============================================================================================
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}