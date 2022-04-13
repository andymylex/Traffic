using System.Collections.Generic;
using Traffic.Enums;

namespace Traffic.Data
{
    /// <summary>
    /// Класс, содержащий данные приложения: список районов и список улиц
    /// </summary>
    public class AppData
    {
        public List<District> Districts { get; private set; }
        public List<Street> Streets { get; private set; }

        public AppData(List<District> districts, List<Street> streets)
        {
            Districts = districts;
            Streets = streets;
        }

        public static AppData DefaultAppData { get { return new AppData(defaultDistricts, defaultStreets); } }

        private static readonly List<District> defaultDistricts = new List<District>() {
            new District("Гидростроителей",     "gidrostroy.png",   "graph\\graph_gidr.bmp"),
            new District("Дубинка+Черемушки",   "dubinka.png",      null            ),
            new District("Комсомольский",       "komsomolsky.png",  null            ),
            new District("Славянский",          "slavyansky.png",   "graph\\graph_slav.bmp"),
            new District("Стасова",             "stasova.png",      null            ),
            new District("Фестивальный",        "festivalny.png",   null            ),
            new District("Юбилейный",           "yubileyni.png",    "graph\\graph_ubil.bmp"),
        };

        private static readonly List<Street> defaultStreets = new List<Street>()
        {
            new Street { Name="Автолюбителей",          District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Адыгейская набережная",  District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Азовская",               District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Алма-Атинская",          District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Амурская",               District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Анапская",               District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Атарбекова",             District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Бабушкина",              District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Благоева",               District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Бородинская",            District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Брюсова",                District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Бургасская",             District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Вишняковой",             District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Волжская",               District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Воровского",             District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Воронежская",            District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Гагарина",               District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Герцена",                District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Гидростроителей",        District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Дежнева",                District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Димитрова",              District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Дунайская",              District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Енисейская",             District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="2-я Заречная",           District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Игнатова",               District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="30-й Иркутской дивизии", District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Кавказская",             District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Калинина",               District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Каляева",                District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Ким",                    District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Камвольная",             District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Красных Партизан",       District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="Круговая",               District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Ковтюха",                District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Ковалева",               District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Кожевенная",             District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Котовского",             District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="2-я Линия",              District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="3-я Линия",              District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Магистральная",          District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Майкопская",             District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Мачуги",                 District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="Минская",                District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Молодежная",             District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Монтажная",              District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Новая",                  District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Новороссийская",         District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="70 лет Октября",         District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Олимпийская",            District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Онежская",               District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Просторная",             District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Северная",               District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="Селезнева",              District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Симиренко",              District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Симферопольская",        District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Скорняжная",             District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Славянская",             District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Сормовская",             District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Сочинская",              District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Ставропольская",         District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Старокубанская",         District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Стасова",                District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Темрюкская",             District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Толбухина",              District=defaultDistricts[3], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Трамвайная",             District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="Трудовой славы",         District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Тургенева",              District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="Тюляева",                District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Уральская",              District=defaultDistricts[2], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Урицкого",               District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Фестивальная",           District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Лизы Чайкиной",          District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Две,   NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Чекистов",               District=defaultDistricts[6], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Две },
            new Street { Name="Черноморская",           District=defaultDistricts[0], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Шевченко",               District=defaultDistricts[1], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна },
            new Street { Name="Ялтинская",              District=defaultDistricts[4], NumberOfLanesOnStart=NumberOfLanesEnum.Три, NumberOfLanesOnEnd=NumberOfLanesEnum.Три },
            new Street { Name="Яна-Полуяна",            District=defaultDistricts[5], NumberOfLanesOnStart=NumberOfLanesEnum.Одна,   NumberOfLanesOnEnd=NumberOfLanesEnum.Одна }
        };
    }
}