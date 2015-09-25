using ArquiteturaExemplo.Dominio.Entidades;
using ArquiteturaExemplo.Dominio.Interfaces.Repositorios;
using ArquiteturaExemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Servicos
{
    public class PedidoService : ServicoBase<Pedido>, IPedidoService
    {
        // só pode ser alterado via construtor
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
            : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public override void Excluir(Pedido entidade)
        {
            throw new InvalidOperationException("O Pedido não pode ser excluído! Use o cancelamento.");
        }

        public void CancelarPedido(Pedido pedido)
        {
            pedido.Cancelar(); // aplica as regras de negócio de cancelamento
            _pedidoRepository.Alterar(pedido); // persiste no banco as alterações
        }
    }
}
