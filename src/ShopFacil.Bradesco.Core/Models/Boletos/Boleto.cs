using FluentValidation;
using ShopFacil.Bradesco.Core.Exceptions;
using ShopFacil.Bradesco.Core.Models.Boletos.Remessas;
using System.Linq;
using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos
{
    public class Boleto
    {
        /// <summary>
        /// Nome do beneficiário/cedente
        /// </summary>
        [JsonPropertyName("beneficiario")]
        public string Beneficiario { get; private set; }
        /// <summary>
        /// Código da carteira
        /// Exemplo: 26
        /// </summary>
        [JsonPropertyName("carteira")]
        public string Carteira { get; private set; }
        /// <summary>
        /// Nosso número (identificador do boleto)
        /// O dígito será calculo pela PlataformaBradesco
        /// </summary>
        [JsonPropertyName("nosso_numero")]
        public string NossoNumero { get; private set; }
        /// <summary>
        /// AAAA-MM-DD
        /// </summary>
        [JsonPropertyName("data_emissao")]
        public string DataEmissao { get; private set; }
        /// <summary>
        /// AAAA-MM-DD
        /// </summary>
        [JsonPropertyName("data_vencimento")]
        public string DataVencimento { get; private set; }
        /// <summary>
        /// Valor do boleto para pagamento.
        /// Exemplo: 1500 = R$ 15,00
        /// </summary>
        [JsonPropertyName("valor_titulo")]
        public long ValorTitulo { get; private set; }
        /// <summary>
        /// Url do logotipo que será exibido no topo do boleto
        /// Exemplo: http://www.privatesetia.com.br/static/img/logo.png
        /// </summary>
        [JsonPropertyName("url_logotipo")]
        public string UrlLogotipo { get; private set; }
        /// <summary>
        /// Mensagem de cabeçalho exibida no topo do boleto
        /// </summary>
        [JsonPropertyName("mensagem_cabecalho")]
        public string MensagemCabecalho { get; private set; }
        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>0</term>
        /// <description>HTML</description>
        /// </item>
        /// <item>
        /// <term>1</term>
        /// <description>Tela com link PDF</description>
        /// </item>
        /// <item>
        /// <term>2</term>
        /// <description>PDF</description>
        /// </item>
        /// </list>
        /// Caso não seja enviado o tipo de
        /// renderização, será utilizado o valor
        /// configurado no Gerenciador do Lojista.
        /// </summary>
        [JsonPropertyName("tipo_renderizacao")]
        public string TipoRenderizacao { get; private set; }

        [JsonPropertyName("instrucoes")]
        public Instrucoes Instrucoes { get; private set; }
        /// <summary>
        /// O valor do atributo [registro] pode ser enviado como nulo. 
        /// Qualquer informação sobre taxas ou tarifas devem ser
        /// verificadas com o Gerente de Contas Bradesco.
        /// </summary>
        [JsonPropertyName("registro")]
        public Registro Registro { get; private set; }

        public Boleto(string beneficiario, string carteira, string nossoNumero, string dataEmissao,
            string dataVencimento, long valorTitulo, string urlLogotipo, string mensagemCabecalho,
            string tipoRenderizacao, Instrucoes instrucoes, Registro registro)
        {
            Beneficiario = beneficiario;
            Carteira = carteira;
            NossoNumero = nossoNumero;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            ValorTitulo = valorTitulo;
            UrlLogotipo = urlLogotipo;
            MensagemCabecalho = mensagemCabecalho;
            TipoRenderizacao = tipoRenderizacao;
            Instrucoes = instrucoes;
            Registro = registro;

            Validate();
        }

        private void Validate()
        {
            var result = new BoletoValidator().Validate(this);
            if (!result.IsValid) throw new BoletoException(string.Join(';', result.Errors.Select(p => p.ErrorMessage)));
        }
    }

    public class BoletoValidator : AbstractValidator<Boleto>
    {
        public BoletoValidator()
        {
            RuleFor(p => p.Beneficiario).NotEmpty().MaximumLength(150);
            RuleFor(p => p.Carteira).NotEmpty().Length(2);
            RuleFor(p => p.DataEmissao).NotEmpty().Length(10);
            RuleFor(p => p.DataVencimento).NotEmpty().Length(10);
            RuleFor(p => p.ValorTitulo).NotEmpty().LessThan(10000000000000);
            RuleFor(p => p.UrlLogotipo).Length(255);
            RuleFor(p => p.MensagemCabecalho).Length(200);
            RuleFor(p => p.TipoRenderizacao).Length(1);
        }
    }
}
