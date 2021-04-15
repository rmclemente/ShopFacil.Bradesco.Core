using System.Text.Json.Serialization;

namespace ShopFacil.Bradesco.Core.Models.Boletos
{
    /// <summary>
    /// O valor do atributo [registro] pode ser enviado como nulo. Qualquer informação sobre taxas ou tarifas devem ser
    /// verificadas com o Gerente de Contas Bradesco.
    /// </summary>
    public class Registro
    {
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: “00000”.
        /// </summary>
        [JsonPropertyName("agencia_pagador")]
        public string AgenciaPagador { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: “00000”.
        /// </summary>
        [JsonPropertyName("razao_conta_pagador")]
        public string RazaoContaPagador { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: “00000000”.
        /// </summary>
        [JsonPropertyName("conta_pagador")]
        public string ContaPagador { get; private set; }
        /// <summary>
        /// Nº Controle do Participante.
        /// A informação que constar do Arquivo Remessa será confirmada no Arquivo Retorno, 
        /// Não será impresso nos boletos de cobrança.
        /// Utilizar apenas letras/números sem acentuação ou caracteres especiais (/*-).
        /// Exemplo: Segurança arquivo remessa.
        /// </summary>
        [JsonPropertyName("controle_participante")]
        public string ControleParticipante { get; private set; }
        /// <summary>
        /// Quantidade de parcelas.
        /// </summary>
        [JsonPropertyName("qtde_parcelas")]
        public int QtdeParcelas { get; private set; }
        /// <summary>
        /// Quantidade de dias para cobrança de multa.
        /// </summary>
        [JsonPropertyName("qtde_dias_multa")]
        public int QtdeDiasMulta { get; private set; }
        /// <summary>
        /// Informa caso deva ser aplicada multa.
        /// </summary>
        [JsonPropertyName("aplicar_multa")]
        public bool AplicarMulta { get; private set; }
        /// <summary>
        /// Informa a porcentagem de multa a  ser aplicada.
        ///Exemplo: 200. Refere-se ao valor de 2,00%.
        /// </summary>
        [JsonPropertyName("valor_percentual_multa")]
        public int ValorPercentualMulta { get; private set; }
        /// <summary>
        /// Valor da multa
        /// Exemplo: 1500. Refere-se ao valor de R$ 15,00.
        /// </summary>
        [JsonPropertyName("valor_multa")]
        public int ValorMulta { get; private set; }
        /// <summary>
        /// Informa o valor de desconto a ser aplicado.
        /// Exemplo: 1500. Refere-se ao valor de R$ 15,00.
        /// </summary>
        [JsonPropertyName("valor_desconto_bonificacao")]
        public int ValorDescontoBonificacao { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "False".
        /// </summary>
        [JsonPropertyName("debito_automatico")]
        public bool DebitoAutomatico { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "False".
        /// </summary>
        [JsonPropertyName("rateio_credito")]
        public bool RateioCredito { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "00".
        /// </summary>
        [JsonPropertyName("endereco_debito_automatico")]
        public string EnderecoDebitoAutomatico { get; private set; }
        /// <summary>
        /// Identificação da ocorrência
        /// 01=Remessa(Geração de um novo Título);
        /// </summary>
        [JsonPropertyName("tipo_ocorrencia")]
        public string TipoOcorrencia { get; private set; }
        /// <summary>
        /// Espécie de Título.
        /// Utilizar: 99=Outros.
        /// </summary>
        [JsonPropertyName("especie_titulo")]
        public string EspecieTitulo { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "00".
        /// </summary>
        [JsonPropertyName("primeira_instrucao")]
        public string PrimeiraInstrucao { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "00".
        /// </summary>
        [JsonPropertyName("segunda_instrucao")]
        public string SegundaInstrucao { get; private set; }
        /// <summary>
        /// Quantidade de dias para cobrança de multa.Não informar 0 à esquerda.
        /// </summary>
        [JsonPropertyName("qtde_dias_juros")]
        public int QtdeDiasJuros { get; private set; }
        /// <summary>
        /// Juros de mora - Valor a ser cobrado por dias de atraso
        /// Exemplo: 1500. Refere-se ao valor de R$ 15,00.
        /// </summary>
        [JsonPropertyName("valor_juros_mora")]
        public int ValorJurosMora { get; private set; }
        /// <summary>
        /// Valor a ser cobrado por dias de atraso
        /// Exemplo: 200000. Refere-se ao valor de 2%.
        /// </summary>
        [JsonPropertyName("percentual_juros_mora")]
        public int PercentualJurosMora { get; private set; }
        /// <summary>
        /// Informa a data limite para ser concedido o desconto.
        /// Exemplo: AAAA-MM-DD.
        /// </summary>
        [JsonPropertyName("data_limite_desconto")]
        public string DataLimiteDesconto { get; private set; }
        /// <summary>
        /// 8 posições numéricas, onde as 3 primeiras posições (esquerda para a direita) são os campos inteiros e as demais posições são de decimais.
        /// NNNDDDDD Onde: N - Inteiros D - Decimais.
        /// Exemplo: 10% - O campo deve ser preenchido 01000000.
        /// Exemplo: 12,12% - O campo deve ser preenchido 01212000 (012,12000).
        /// </summary>
        [JsonPropertyName("valor_desconto")]
        public int ValorDesconto { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "0".
        /// </summary>
        [JsonPropertyName("valor_iof")]
        public int ValorIof { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "00".
        /// </summary>
        [JsonPropertyName("valor_abatimento")]
        public int ValorAbatimento { get; private set; }
        /// <summary>
        /// Identificação do Tipo de Inscrição do
        /// Pagador.
        /// 01=CPF;
        /// 02=CNPJ;
        /// </summary>
        [JsonPropertyName("tipo_inscricao_pagador")]
        public string TipoInscricaoPagador { get; private set; }
        /// <summary>
        /// Campo não utilizado no Comércio Eletrônico, o mesmo será desconsiderado.
        /// Utilizar: "00".
        /// </summary>
        [JsonPropertyName("sequencia_registro")]
        public string SequenciaRegistro { get; private set; }

        public Registro(string agenciaPagador, string razaoContaPagador, string contaPagador,
            string controleParticipante, int qtdeParcelas, int qtdeDiasMulta, bool aplicarMulta,
            int valorPercentualMulta, int valorMulta, int valorDescontoBonificacao, bool debitoAutomatico,
            bool rateioCredito, string enderecoDebitoAutomatico, string tipoOcorrencia, string especieTitulo,
            string primeiraInstrucao, string segundaInstrucao, int qtdeDiasJuros, int valorJurosMora,
            int percentualJurosMora, string dataLimiteDesconto, int valorDesconto, int valorIof,
            int valorAbatimento, string tipoInscricaoPagador, string sequenciaRegistro)
        {
            AgenciaPagador = agenciaPagador;
            RazaoContaPagador = razaoContaPagador;
            ContaPagador = contaPagador;
            ControleParticipante = controleParticipante;
            QtdeParcelas = qtdeParcelas;
            QtdeDiasMulta = qtdeDiasMulta;
            AplicarMulta = aplicarMulta;
            ValorPercentualMulta = valorPercentualMulta;
            ValorMulta = valorMulta;
            ValorDescontoBonificacao = valorDescontoBonificacao;
            DebitoAutomatico = debitoAutomatico;
            RateioCredito = rateioCredito;
            EnderecoDebitoAutomatico = enderecoDebitoAutomatico;
            TipoOcorrencia = tipoOcorrencia;
            EspecieTitulo = especieTitulo;
            PrimeiraInstrucao = primeiraInstrucao;
            SegundaInstrucao = segundaInstrucao;
            QtdeDiasJuros = qtdeDiasJuros;
            ValorJurosMora = valorJurosMora;
            PercentualJurosMora = percentualJurosMora;
            DataLimiteDesconto = dataLimiteDesconto;
            ValorDesconto = valorDesconto;
            ValorIof = valorIof;
            ValorAbatimento = valorAbatimento;
            TipoInscricaoPagador = tipoInscricaoPagador;
            SequenciaRegistro = sequenciaRegistro;
        }
    }
}