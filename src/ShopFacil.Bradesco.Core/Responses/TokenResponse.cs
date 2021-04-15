using ShopFacil.Bradesco.Core.Models.Boletos.Retornos;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Responses
{
    public class TokenResponse
    {
        [JsonPropertyName("status")]
        public StatusResponse Status { get; set; }

        [JsonPropertyName("token")]
        public AccessToken AccessToken { get; set; }

        [JsonPropertyName("pedidos")]
        public List<PedidoResponse> Pedidos { get; set; }

        [JsonPropertyName("paging")]
        public Paging Paging { get; set; }
    }

}
