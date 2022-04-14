using LiveCharts;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using Traffic.Data;
using Traffic.Enums;
using Traffic.Tools;

namespace Traffic
{
    public partial class TrafficJamsWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICollectionView _streetsView;
        private Street _selectedStreet = (Application.Current as App).CurrentAppData.Streets[0];
        private uint _trafficIntensity;
        private uint _maxPracticalBandwidth;
        private uint _roadLoad;
        private uint _fare;
        private double _consumerExcess;
        private uint _profitAmount;

        public ICollectionView StreetsView
        {
            get
            {
                if (_streetsView == null)
                {
                    _streetsView = CollectionViewSource.GetDefaultView((Application.Current as App).CurrentAppData.Streets);
                    if (_streetsView.GroupDescriptions.Count == 0)
                    {
                        _streetsView.GroupDescriptions.Add(new PropertyGroupDescription("District.Name"));
                        _streetsView.SortDescriptions.Add(new SortDescription("District.Name", ListSortDirection.Ascending));
                        _streetsView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    }
                }
                return _streetsView;
            }
        }
        public Street SelectedStreet
        {
            get { return _selectedStreet; }
            set
            {
                _selectedStreet = value;
                webView.Source = new Uri($"https://yandex.ru/maps/35/krasnodar/search/улица {_selectedStreet.Name}");
                OnPropertyChanged();
                OnPropertyChanged("DistrictImage");
            }
        }
        public RoadConditionEnum RoadCondition { get; set; } = RoadConditionEnum.AsphaltExcellent;
        public MovementDirectionEnum MovementDirection { get; set; } = MovementDirectionEnum.Entry; // TODO: задействовать
        public uint TrafficIntensity
        {
            get { return _trafficIntensity; }
            set
            {
                _trafficIntensity = value;
                OnPropertyChanged();
            }
        }
        public uint MaxAllowedSpeed { get; set; } = 60;
        public uint MaxPracticalBandwidth
        {
            get { return _maxPracticalBandwidth; }
            set
            {
                _maxPracticalBandwidth = value;
                OnPropertyChanged();
            }
        }
        public uint RoadCongestion
        {
            get { return _roadLoad; }
            set
            {
                _roadLoad = value;
                OnPropertyChanged();
            }
        }
        public uint Tariff { get; set; } = 100;
        public uint PotentialDemand { get; set; } = 10;
        public uint Fare
        {
            get { return _fare; }
            set
            {
                _fare = value;
                OnPropertyChanged();
            }
        }
        public double ConsumerExcess
        {
            get { return _consumerExcess; }
            set
            {
                _consumerExcess = value;
                OnPropertyChanged();
            }
        }
        public uint TransportFlow { get; set; } = 50;
        public uint ProfitAmount
        {
            get { return _profitAmount; }
            set
            {
                _profitAmount = value;
                OnPropertyChanged();
            }
        }
        public ImageSource DistrictImage
        {
            get
            {
                return HelperTools.GetImageSourceFromPath(SelectedStreet.District.ImageFilename);
            }
        }

        public TrafficJamsWindow() => InitializeComponent();

        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void MaxPracticalBandwidthButton_Click(object sender, RoutedEventArgs e)
        {
            HelperTools.CatchError(() =>
            {
                MaxPracticalBandwidth = Calculations.CalcMaxPracticalBandwidth(
                    SelectedStreet.NumberOfLanesOnStart,
                    SelectedStreet.NumberOfLanesOnEnd,
                    MaxAllowedSpeed,
                    RoadCondition);
            });
        }

        private void RoadCongestionButton_Click(object sender, RoutedEventArgs e)
        {
            HelperTools.CatchError(() =>
            {
                TrafficIntensity = Calculations.CalcTrafficIntensity(SelectedStreet.NumberOfLanesOnStart, SelectedStreet.NumberOfLanesOnEnd);
                RoadCongestion = Calculations.CalcRoadCongestion(TrafficIntensity, MaxPracticalBandwidth);
            });
        }

        private void FareButton_Click(object sender, RoutedEventArgs e)
        {
            FareDialogWindow dialog = new FareDialogWindow();
            dialog.ShowDialog();
            Fare = (uint)dialog.Fare;
        }

        private void DemandChartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChartValues<double> values = new ChartValues<double>();
                for (int i = 0; i <= 30; i++)
                {
                    if (i == 0)
                    {
                        values.Add(TrafficIntensity);   // TODO: убрать костыль
                    }
                    else
                    {
                        values.Add((double)TrafficIntensity / i);
                    }
                }
                new ChartWindow(values).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConsumerExcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double aw = PotentialDemand;
                double cw = Fare;
                double dw = aw * 2.7 * (-cw / 0.05);
                double f2 = dw * 0.05;
                ConsumerExcess = f2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProfitAmountButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProfitAmount = Tariff * TransportFlow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExcessChartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChartValues<double> values = new ChartValues<double>();
                for (int i = 0; i <= Tariff; i++)
                {
                    if (i == 0)
                    {
                        values.Add(ConsumerExcess);
                    }
                    else
                    {
                        values.Add(ConsumerExcess / i);
                    }
                }
                new ChartWindow(values).ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ProfitChartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ChartValues<double> values = new ChartValues<double>();
                for (int i = 0; i <= Tariff; i++)
                {
                    if (i == 0)
                    {
                        values.Add(ProfitAmount);  // убрать костыль
                    }
                    else
                    {
                        values.Add(ProfitAmount / i);
                    }
                }
                new ChartWindow(values).ShowDialog();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new ImageWindow((sender as Image).Source).ShowDialog();
        }
    }
}
