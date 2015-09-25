using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Entidades.Interfaces
{
    /// <summary>
    /// Interface implementada por todas as entidades que precisem de validação
    /// </summary>
    public interface IValidaEntidade
    {
        void ValidarEntidade();
    }
}
