using System.Text.Json.Serialization;

namespace BooksWorld.Domain.Common.Enums
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BookFormat
    {
        Paper = 1,
        Electronic = 2,
        Audio = 4,
    }
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Language
    {
        None = 0,
        Armenian = 1,
        France = 2,
        English = 4,
        Russian = 8,
        German = 32,
        Italian = 64
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortingType
    {
        Popular,
        Rating,
        Price,
    }
}