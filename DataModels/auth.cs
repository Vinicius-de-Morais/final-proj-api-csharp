using System.Text.Json.Serialization;

namespace api_projeto_final.DataModels
{
    public class auth
    {

        [JsonIgnore]
        public int id { get; set; }
        public int userId { get; set; }
        [JsonIgnore]
        public user? user { get; set; }
        public string password_hashed { get; set; }
        public string password_salt { get; set; }
    }
}
