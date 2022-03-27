using System.Windows;

namespace Traffic.Windows
{
    /// <summary>
    /// Главное окно приложения
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void StatisticsButton_Click(object sender, RoutedEventArgs e) => ShowWindow(new StatisticsWindow());

        private void TrafficJamsButton_Click(object sender, RoutedEventArgs e) => ShowWindow(new TrafficJamsWindow());

        private void GraphButton_Click(object sender, RoutedEventArgs e) => ShowWindow(new GraphWindow());

        private void EditorButton_Click(object sender, RoutedEventArgs e) => ShowWindow(new EditorWindow());

        private void ShowWindow(Window window)
        {
            Hide();
            window.ShowDialog();
            Show();
        }
    }
}