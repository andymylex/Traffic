using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Traffic.Enums;
using Traffic.Tools;

namespace Traffic.Windows
{
    /// <summary>
    /// Окно "Статистика"
    /// </summary>
    public partial class StatisticsWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private uint _carsInTraffic;
        private uint _intensity;
        private uint _bandwidth;

        public uint NumberOfCars { get; set; } = 10;
        public uint NumberOfMotorcycles { get; set; }
        public uint NumberOfTrucks { get; set; }
        public uint NumberOfRoadTrains { get; set; }
        public uint CarsInTraffic
        {
            get => _carsInTraffic;
            set
            {
                _carsInTraffic = value;
                OnPropertyChanged();
            }
        }
        public NumberOfLanesEnum NumberOfLanes { get; set; } = NumberOfLanesEnum.Одна;
        public RoadConditionEnum RoadCondition { get; set; } = RoadConditionEnum.AsphaltExcellent;
        public uint MaxAllowedSpeed { get; set; } = 60;
        public uint Slope { get; set; }
        public uint TrafficIntensity
        {
            get => _intensity;
            set
            {
                _intensity = value;
                OnPropertyChanged();
            }
        }
        public uint MaxTheoreticalBandwidth
        {
            get => _bandwidth;
            set
            {
                _bandwidth = value;
                OnPropertyChanged();
            }
        }

        public StatisticsWindow() => InitializeComponent();

        protected void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void TrafficIntensityButton_Click(object sender, RoutedEventArgs e)
        {
            HelperTools.CatchError(() =>
            {
                CarsInTraffic = Calculations.CalcCarsInTraffic(NumberOfCars, NumberOfMotorcycles, NumberOfTrucks, NumberOfRoadTrains);
                TrafficIntensity = Calculations.CalcTrafficIntensity(NumberOfCars, NumberOfMotorcycles, NumberOfTrucks, NumberOfRoadTrains);
            });
        }

        private void MaxTheoreticalBandwidthButton_Click(object sender, RoutedEventArgs e)
        {
            HelperTools.CatchError(() =>
                    MaxTheoreticalBandwidth = Calculations.CalcMaxTheoreticalBandwidth(
                    NumberOfCars,
                    NumberOfMotorcycles,
                    NumberOfTrucks,
                    NumberOfRoadTrains,
                    MaxAllowedSpeed,
                    Slope,
                    RoadCondition,
                    NumberOfLanes
                )
            );
        }
    }
}