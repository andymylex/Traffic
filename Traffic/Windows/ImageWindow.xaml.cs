using System.Windows;
using System.Windows.Media;

namespace Traffic
{
    public partial class ImageWindow : Window
    {
        public ImageWindow(ImageSource image)
        {
            InitializeComponent();
            Image.Source = image;
        }
    }
}
