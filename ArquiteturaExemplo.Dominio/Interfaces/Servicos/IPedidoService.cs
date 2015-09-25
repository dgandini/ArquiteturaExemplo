using ArquiteturaExemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Interfaces.Servicos
{
    public interface IPedidoService : IServicoBase<Pedido>
    {
        void CancelarPedido(Pedido pedido);
    }
}
