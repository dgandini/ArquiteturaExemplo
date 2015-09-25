using ArquiteturaExemplo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Dados.EntityFramework.Configuracoes
{
    class PedidoConfiguration : ConfiguracaoBase<Pedido>
    {
        public PedidoConfiguration()
        {
            ToTable("TB_Pedido");
            HasKey(x => x.IdPedido);

            Property(x => x.IdPedido)
                .HasColumnName("IdPedido")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Cliente)
                .HasColumnName("Cliente")
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.DataPedido)
                .HasColumnName("DataPedido")
                .IsRequired();

            // o valor é calculado e não será armazenado no banco de dados
            Ignore(x => x.ValorTotal);

            Property(x => x.Status)
                .HasColumnName("StatusPedido")
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
