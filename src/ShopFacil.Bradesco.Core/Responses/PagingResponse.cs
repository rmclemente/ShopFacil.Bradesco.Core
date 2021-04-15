using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Responses
{
    public class Paging
    {
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("currentOffset")]
        public int CurrentOffset { get; set; }

        [JsonPropertyName("nextOffset")]
        public int NextOffset { get; set; }
    }
}
