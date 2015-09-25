using ArquiteturaExemplo.Dominio.Entidades.Interfaces;
using ArquiteturaExemplo.Infra.Comum.Resources;
using ArquiteturaExemplo.Infra.Comum.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Entidades
{
    public class Pedido : EntidadeBase
    {
        protected Pedido()
        {
            Itens = new List<ItemPedido>();
        }

        public Pedido(string cliente)
        {
            // regras para a criação de uma nova instância de pedido
            Cliente = cliente;
            DataPedido = DateTime.Now;
            Status = "Novo";
        }

        public Pedido(int idPedido, string cliente, DateTime dataPedido)
        {
            // regras para a criação de uma nova instância de pedido
            IdPedido = idPedido;
            Cliente = cliente;
            DataPedido = dataPedido;
            Status = "Alterado";
        }

        public int IdPedido { get; private set; }
        // String apenas para simplificar o exemplo (poderia ser do tipo Cliente)
        public string Cliente { get; private set; } 
        public DateTime DataPedido { get; private set; }
        
        public decimal ValorTotal
        {
            get { return Itens.Sum(x => x.Valor); }
        }
        
        
        // String apenas para simplificar o exemplo 
        public string Status { get; private set; }

        public virtual ICollection<ItemPedido> Itens { get; set; }
        
        // um cancelamento implica em voltar mercadoria para o estoque entre outras coisas, 
        // portanto numa situação real não seria apenas alterar o status ou tampouco excluir
        // *** cada empresa tem suas regras de negócio para cancelamento de pedidos
        public void Cancelar()
        {
            Status = "Cancelado";

            foreach(var item in Itens)
            {
                item.CancelarItem();
            }
        }

        // Ex.: outros métodos com regras de negócios CalcularFrete(), CalcularImpostos(), Finalizar() e etc

        // Valida a entidade (Override do método base que apenas retorna uma exception)
        public override void ValidarEntidade()
        {
            AssertionConcern.AssertArgumentNotEmpty(Cliente, MensagemErroResource.ErroClienteNaoInformado);
            AssertionConcern.AssertArgumentNotEmpty(Status, MensagemErroResource.ErroStatusPedidoNaoInformado);
        }

    }
}
