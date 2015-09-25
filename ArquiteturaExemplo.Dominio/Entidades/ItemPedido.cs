using ArquiteturaExemplo.Infra.Comum.Resources;
using ArquiteturaExemplo.Infra.Comum.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Entidades
{
    public class ItemPedido : EntidadeBase
    {
        public int IdItemPedido { get; private set; }
        public int IdPedido { get; private set; } // FK

        public string Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
        public string Status { get; private set; }

        public decimal Valor
        {
            get { return Quantidade * PrecoUnitario; }
        }
        
        // Navegacao
        public virtual Pedido Pedido { get; set; }

        public void CancelarItem()
        {
            Status = "Cancelado";
        }

        public override void ValidarEntidade()
        {
            AssertionConcern.AssertArgumentNotEmpty(Produto, MensagemErroResource.ErroProdutoNaoInformado);
            AssertionConcern.AssertArgumentFalse(Quantidade <= 0, MensagemErroResource.ErroQuantidadeNaoInformada);
            AssertionConcern.AssertArgumentFalse(PrecoUnitario <= 0, MensagemErroResource.ErroValorUnitarioNaoInformado);
        }

    }
}
