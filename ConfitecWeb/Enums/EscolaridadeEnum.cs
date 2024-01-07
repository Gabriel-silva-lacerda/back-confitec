using System.Text.Json.Serialization;

namespace ConfitecWeb.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EscolaridadeEnum
    {
        Infantil, 
        Fundamental, 
        Médio, 
        Superior
    }
}
