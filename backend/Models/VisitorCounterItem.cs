using System.Text.Json.Serialization;

namespace VisitorCounterFunction
{
    public class VisitorCounterItem
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }
    } 
}