using FluentValidation;
using ShopFacil.Bradesco.Core.Exceptions;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos
{
    public class Pedido
    {
        /// <summary>
        /// Identificador do pedido na loja
        /// </summary>
        [JsonPropertyName("numero")]
        public string Numero { get; private set; }
        /// <summary>
        /// Valor do pedido.
        /// Exemplo: 1500 = R$ 15,00
        /// </summary>
        [JsonPropertyName("valor")]
        public long Valor { get; private set; }
        /// <summary>
        /// Descrição da compra
        /// Exemplo: Kit 2 Cartuchos Hp Extra Vol. 13
        /// </summary>
        [JsonPropertyName("descricao")]
        public string Descricao { get; private set; }

        public Pedido(string numero, long valor, string descricao)
        {
            Numero = numero;
            Valor = valor;
            Descricao = descricao;

            Validate();
        }

        private void Validate()
        {
            var result = new PedidoValidator().Validate(this);
            if (!result.IsValid) throw new BoletoException(string.Join(';', result.Errors.Select(p => p.ErrorMessage)));
        }
    }

    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(p => p.Numero).NotEmpty().MaximumLength(27).Matches("(^[AZa-z0-9\\._]*\\d+[A-Za-z0-9\\._-]*$)");
            RuleFor(p => p.Valor).NotEmpty().LessThan(10000000000000);
            RuleFor(p => p.Descricao).NotEmpty().MaximumLength(255);
        }
    }
}