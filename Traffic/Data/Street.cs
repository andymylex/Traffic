using Traffic.Enums;

namespace Traffic.Data
{
    /// <summary>
    /// Улица города
    /// </summary>
    public class Street
    {
        public string Name { get; set; }
        public District District { get; set; }
        public NumberOfLanesEnum NumberOfLanesOnStart { get; set; }
        public NumberOfLanesEnum NumberOfLanesOnEnd { get; set; }
    }
}