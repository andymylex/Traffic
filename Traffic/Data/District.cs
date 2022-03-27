using Newtonsoft.Json;

namespace Traffic.Data
{
    /// <summary>
    /// Район города
    /// </summary>
    [JsonObject(IsReference = true)]
    public class District
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string ImageFilename { get; set; }
        public string GraphImageFilename { get; set; }

        // TODO: remove constructor
        public District(string name, string imageFilename, string graphImageFilename)
        {
            Name = name;
            ImageFilename = imageFilename;
            GraphImageFilename = graphImageFilename;
        }
    }
}
