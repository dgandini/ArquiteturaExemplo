using ArquiteturaExemplo.Dominio.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Entidades
{
    public class EntidadeBase : IEntidadeBase, IValidaEntidade
    {
        public DateTime DataCadastro {get; set;}
        public DateTime DataAlteracao { get; set; }

        // virtual para que possa ser sobrescrita na subclasse
        public virtual void ValidarEntidade() 
        {
            // deixar a exception para forçar a implementação pelas subclasses
            throw new NotImplementedException();
        }
    }
}
