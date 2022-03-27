using System.Windows;

namespace Traffic
{
    public partial class BaseRateWindow : Window
    {
        public BaseRateWindow()
        {
            InitializeComponent();
            BaseRateTextBox.Text = Properties.Resources.base_rate;  // TODO: word file
        }
    }
}
