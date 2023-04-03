using System.Text.Json.Serialization;

namespace Types.Responses
{
    public record ItemResponse
    {
        [JsonPropertyName("itemId")]
        public int ItemId { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }
    }
}