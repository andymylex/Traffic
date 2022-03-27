using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace Traffic
{
    public partial class EditorWindow : Window
    {
        public EditorWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DistrictsDataGrid.ItemsSource = (Application.Current as App).CurrentAppData.Districts;
            StreetsDataGrid.ItemsSource = (Application.Current as App).CurrentAppData.Streets;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string output = JsonConvert.SerializeObject((Application.Current as App).CurrentAppData, new JsonSerializerSettings { Formatting = Formatting.Indented });
            File.WriteAllText("data.json", output);
        }
    }
}
