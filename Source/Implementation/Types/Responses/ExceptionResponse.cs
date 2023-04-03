using System.Net;
using System.Text.Json.Serialization;

namespace Types.Responses
{
    public record ExceptionResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; init; }

        [JsonPropertyName("statusCode")]
        public HttpStatusCode StatusCode { get; init; }
    }
}