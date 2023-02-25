using System.Text.Json.Serialization;

namespace code_net.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CharacterClass
    {
        Strength = 1,
        Agility = 2,
        Intelligence = 3
    }
}