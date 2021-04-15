using FluentValidation;
using ShopFacil.Bradesco.Core.Exceptions;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos
{
    public class Remessa
    {
        /// <summary>
        /// Identificador do estabelecimento fornecido pelo Bradesco
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; private set; }
        /// <summary>
        /// Valor fixo: 300 (Boleto)
        /// </summary>
        [JsonPropertyName("meio_pagamento")]
        public string MeioPagamento { get; private set; }

        [JsonPropertyName("pedido")]
        public Pedido Pedido { get; private set; }

        [JsonPropertyName("comprador")]
        public Comprador Comprador { get; private set; }

        [JsonPropertyName("boleto")]
        public Boleto Boleto { get; private set; }

        [JsonPropertyName("token_request_confirmacao_pagamento")]
        public string TokenRequestConfirmacaoPagamento { get; private set; }

        public Remessa(string merchantId, string meioPagamento, Pedido pedido, Comprador comprador,
            Boleto boleto, string tokenRequestConfirmacaoPagamento = null)
        {
            MerchantId = merchantId;
            MeioPagamento = meioPagamento;
            Pedido = pedido;
            Comprador = comprador;
            Boleto = boleto;
            TokenRequestConfirmacaoPagamento = tokenRequestConfirmacaoPagamento;

            Validate();
        }

        private void Validate()
        {
            var result = new RemessaValidator().Validate(this);
            if (!result.IsValid) throw new BoletoException(string.Join(';', result.Errors.Select(p => p.ErrorMessage)));
        }
    }

    public class RemessaValidator : AbstractValidator<Remessa>
    {
        public RemessaValidator()
        {
            RuleFor(p => p.MerchantId).NotEmpty().Length(9);
            RuleFor(p => p.MeioPagamento).NotEmpty().Equals("300");
        }
    }
}
