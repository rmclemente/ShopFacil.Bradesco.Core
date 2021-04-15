using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Responses
{
    public class AccessToken
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("dataCriacao")]
        public string DataCriacao { get; set; }
    }

}
