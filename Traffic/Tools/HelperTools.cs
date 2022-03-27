using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Traffic.Tools
{
    /// <summary>
    /// Класс со вспомогательными методами
    /// </summary>
    internal static class HelperTools
    {
        /// <summary>
        /// Возвращает ImageSource, созданный из файла изображения по указанному пути
        /// </summary>
        /// <param name="path">Путь к файлу с изображением относительно папки "images"</param>
        /// <returns>ImageSource</returns>
        public static ImageSource GetImageSourceFromPath(string path)
        {
            return new BitmapImage(new Uri(Path.Combine(Environment.CurrentDirectory, "images", path)));
        }

        // TODO: remove
        /// <summary>
        /// Возвращает индекс отмеченного RadioButton в StackPanel в GroupBox
        /// </summary>
        /// <param name="groupBox">GroupBox, содержащий элементы RadioButton</param>
        /// <returns>Индекс отмеченного RadioButton</returns>
        public static int GetCheckedRadioButtonIndex(GroupBox groupBox)
        {
            int i = 0;

            foreach (RadioButton rb in ((StackPanel)groupBox.Content).Children)
            {
                if (rb.IsChecked == true)
                {
                    return i;
                }

                i++;
            }

            return -1;
        }

        /// <summary>
        /// Выполняет заданное действие и при возникновении исключения открывает диалоговое окно с его описанием
        /// </summary>
        /// <param name="action">Заданное действие</param>
        public static void CatchError(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Выполняет заданное действие и при возникновении исключения открывает диалоговое окно с его описанием, а также выполняет специальной действие
        /// </summary>
        /// <param name="action">Заданное действие</param>
        /// <param name="actionIfExceptionCaught">Действие при возникновении исключения</param>
        public static void CatchError(Action action, Action actionIfExceptionCaught)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                actionIfExceptionCaught();
            }
        }
    }
}