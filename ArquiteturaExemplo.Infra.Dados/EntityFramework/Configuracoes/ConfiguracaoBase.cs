using ArquiteturaExemplo.Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Dados.EntityFramework.Configuracoes
{
    class ConfiguracaoBase<T> : EntityTypeConfiguration<T> where T : class, IEntidadeBase
    {
        public ConfiguracaoBase()
        {
            Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro")
                .IsRequired();

            Property(x => x.DataAlteracao)
                .HasColumnName("DataAlteracao")
                .IsRequired();
        }
    }
}
