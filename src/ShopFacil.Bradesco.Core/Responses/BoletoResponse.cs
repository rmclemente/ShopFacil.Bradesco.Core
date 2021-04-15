using System;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Responses
{
    public class BoletoResponse
    {
        [JsonPropertyName("data_geracao")]
        public DateTime DataGeracao { get; set; }

        [JsonPropertyName("data_atualizacao")]
        public object DataAtualizacao { get; set; }

        [JsonPropertyName("linha_digitavel")]
        public string LinhaDigitavel { get; set; }

        [JsonPropertyName("linha_digitavel_formatada")]
        public string LinhaDigitavelFormatada { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("url_acesso")]
        public string UrlAcesso { get; set; }
    }
}