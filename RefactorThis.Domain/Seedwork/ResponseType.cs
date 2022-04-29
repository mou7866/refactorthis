using System.Text.Json.Serialization;

namespace RefactorThis.Domain.Seedwork
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ResponseType
    {
        SUCCESS = 0,
        INFO = 1,
        WARNING = 2,
        FAILURE = 3
    }
}
