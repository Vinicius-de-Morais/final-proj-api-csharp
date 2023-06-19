using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace api_projeto_final.DataModels
{
    public class token
    {

        [JsonIgnore]
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public string token_value { get; set; }
        public user? user { get; set; }
        public DateTimeOffset created_at { get; set; }
        public DateTimeOffset expires_at { get; set; }
    }
}
