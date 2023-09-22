

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebServer_Server.Responses
{
    public class PeopleResponse
    {

        public int Age { get; set; }

        [JsonPropertyName("people_name")]
        public string Name { get; set; }
    }
}
