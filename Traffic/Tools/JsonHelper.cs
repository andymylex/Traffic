using Newtonsoft.Json;
using System.IO;
using Traffic.Data;

namespace Traffic
{
    /// <summary>
    /// Класс для работы с JSON файлом с данными приложения
    /// </summary>
    internal static class JsonHelper
    {
        private static readonly string appDataPath = "data.json";

        /// <summary>
        /// Сохраняет стандартные данные в JSON файл
        /// </summary>
        public static void SaveDefaultData()
        {
            string output = JsonConvert.SerializeObject(AppData.DefaultAppData, new JsonSerializerSettings { Formatting = Formatting.Indented });
            File.WriteAllText(appDataPath, output);
        }

        /// <summary>
        /// Считывает данные приложения из JSON файла
        /// </summary>
        /// <returns>Данные приложения</returns>
        public static AppData LoadAppData()
        {
            return JsonConvert.DeserializeObject<AppData>(File.ReadAllText(appDataPath));
        }
    }
}