using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Entidades.Interfaces
{
    /// <summary>
    /// Interface básica que deverá ser herdada e implementada por todas as entidades
    /// </summary>
    public interface IEntidadeBase
    {
        // poderia ter mais informações como Usuário que alterou e demais atributos ou operações comuns
        DateTime DataCadastro { get; set; }
        DateTime DataAlteracao { get; set; }
    }
}
