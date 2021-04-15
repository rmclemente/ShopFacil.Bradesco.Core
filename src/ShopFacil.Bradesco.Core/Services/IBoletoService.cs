using ShopFacil.Bradesco.Core.Models.Boletos;
using ShopFacil.Bradesco.Core.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ShopFacil.Bradesco.Core.Services
{
    public interface IBoletoService
    {
        Task<Response> GerarBoleto(Remessa remessa, CancellationToken cancellationToken = default);
        Task<List<PedidoResponse>> GetOrderListPayment(DateTime dataInicial, DateTime dataFinal, int? status = null, int offset = 1, int limit = 100, CancellationToken cancellationToken = default);
        Task<List<PedidoResponse>> GetOrderById(string orderId, CancellationToken cancellationToken = default);
    }
}
