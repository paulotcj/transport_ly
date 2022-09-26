using System.Text.Json.Serialization;


namespace Transport_ly.Model.DTO
{
    //note: We will need to use a dictionary for this: <string, OrderJsonDto>
    public class OrderJson
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; }

    }
}
