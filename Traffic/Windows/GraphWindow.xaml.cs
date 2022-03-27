using System;
using System.Collections.Generic;
using System.Windows;
using Traffic.Data;
using Traffic.Tools;

namespace Traffic
{
    public partial class GraphWindow : Window
    {
        public GraphWindow()
        {
            InitializeComponent();
        }

        private readonly List<int> AddedDistictsIndexes = new List<int>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            foreach (District district in (Application.Current as App).CurrentAppData.Districts)
            {
                if (district.GraphImageFilename != null)
                {
                    DistrictComboBox.Items.Add(district.Name);
                    AddedDistictsIndexes.Add(i);
                }
                i++;
            }
            DistrictComboBox.SelectedIndex = 0;
        }

        private void DistrictComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                DistrictImage.Source = HelperTools.GetImageSourceFromPath((Application.Current as App).CurrentAppData.Districts[AddedDistictsIndexes[DistrictComboBox.SelectedIndex]].GraphImageFilename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
