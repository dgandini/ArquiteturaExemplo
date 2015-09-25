using ArquiteturaExemplo.Aplicacao.Interfaces;
using ArquiteturaExemplo.Dominio.Entidades;
using ArquiteturaExemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Aplicacao
{
    public class PedidoAppService : AppServiceBase<Pedido>, IPedidoAppService
    {
        private readonly IPedidoService _servicoPedido;

        public PedidoAppService(IPedidoService servicoPedido)
            : base(servicoPedido)
        {
            _servicoPedido = servicoPedido;
        }

        public void CancelarPedido(Pedido pedido)
        {
            _servicoPedido.CancelarPedido(pedido);
            // aqui vão outras regras da app relativas ao cancelamento como, por exemplo, notificações via email
            // ou outras regras não específicas do negócio, mas sim da aplicação
        }
    }
}
