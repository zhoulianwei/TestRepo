using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebServer_Server.Requests
{
    public class PeopleRequest
    {
        [JsonPropertyName("people_id")]
        public int Id { get; set; }
    }
}
