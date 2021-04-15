using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Responses
{
    public class PedidoResponse
    {
        [JsonPropertyName("numero")]
        public string Numero { get; set; }

        [JsonPropertyName("valor")]
        public long Valor { get; set; }

        [JsonPropertyName("descricao")]
        public string Descricao { get; set; }

        [JsonPropertyName("data")]
        public string Data { get; set; }

        [JsonPropertyName("linhaDigitavel")]
        public string LinhaDigitavel { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("erro")]
        public string Erro { get; set; }
    }
}