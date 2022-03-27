using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;

namespace Traffic
{
    public partial class ChartWindow : Window
    {
        public SeriesCollection SeriesCollection { get; } = new SeriesCollection();

        public ChartWindow(ChartValues<double> values)
        {
            InitializeComponent();
            DataContext = this;
            SeriesCollection.Add(new LineSeries { Values = values, Title = "" });
        }
    }
}
