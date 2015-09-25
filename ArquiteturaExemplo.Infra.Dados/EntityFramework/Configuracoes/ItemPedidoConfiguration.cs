using ArquiteturaExemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Dados.EntityFramework.Configuracoes
{
    // Herda os atributos configurados na ConfiguracaoBase, portanto não há necessidade de mapea-los aqui novamente
    class ItemPedidoConfiguration : ConfiguracaoBase<ItemPedido>
    {
        public ItemPedidoConfiguration()
        {
            ToTable("TB_ItemPedido");
            HasKey(x => x.IdItemPedido);

            Property(x => x.IdItemPedido)
                .HasColumnName("IdItemPedido")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.IdPedido)
                .HasColumnName("IdPedido")
                .IsRequired();

            Property(x => x.Produto)
                .HasColumnName("NomeProduto")
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.Quantidade)
                .HasColumnName("QuantidadePedida")
                .IsRequired();

            Property(x => x.PrecoUnitario)
                .HasColumnName("ValorUnitario")
                .IsRequired();

            Property(x => x.Status)
                .HasColumnName("StatusPedido")
                .HasMaxLength(20)
                .IsRequired();

            // o valor é calculado e não será armazenado no banco de dados
            Ignore(x => x.Valor);

            // Chave estrangeira
            //HasRequired(a => a.Pedido).WithMany(b => b.Itens).HasForeignKey(c => c.IdPedido);

        }
    }
}
