using System;
using System.Windows;

namespace Traffic
{
    public partial class FareDialogWindow : Window
    {
        public int Fare { get; set; }

        public FareDialogWindow()
        {
            InitializeComponent();
        }

        private void BaseRateButton_Click(object sender, RoutedEventArgs e)
        {
            new BaseRateWindow().ShowDialog();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Fare = (int)Math.Truncate((double.Parse(BaseRateTextBox.Text) * double.Parse(SleepTimeTextBox.Text) * double.Parse(PriceTextBox.Text)) / 573);
                FareTextBox.Text = Fare.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
