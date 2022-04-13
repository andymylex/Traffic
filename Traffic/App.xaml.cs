using System.Windows;
using Traffic.Data;

namespace Traffic
{
    /// <summary>
    /// Главный класс приложения
    /// </summary>
    public partial class App : Application
    {
        private readonly bool useDefaultData = false;

        public AppData CurrentAppData { get; private set; }

        private App()
        {
            if (useDefaultData) JsonHelper.SaveDefaultData();
            Tools.HelperTools.CatchError(() => CurrentAppData = JsonHelper.LoadAppData(), () => Shutdown());
        }
    }
}