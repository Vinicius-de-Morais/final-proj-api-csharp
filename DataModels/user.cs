using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_projeto_final.DataModels
{
    public class user
    {
        [JsonIgnore]
        public int id { get; set; }
        [MaxLength(50)]
        public string username { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public auth? auth { get; set; }
        [JsonIgnore]
        public token? token { get; set; }

        [NotMapped]
        public string? password { get; set;}
    }
}
