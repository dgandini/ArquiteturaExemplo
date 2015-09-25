using ArquiteturaExemplo.Dominio.Entidades;
using ArquiteturaExemplo.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Dados.Repositorios
{
    public class PedidoRepositoryEf : RepositorioBase<Pedido>, IPedidoRepository
    {
    }
}
