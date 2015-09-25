﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Aplicacao.Interfaces
{
    public interface IAppServiceBase<T> : IDisposable where T : class
    {
        void Incluir(T entidade);
        void Excluir(T entidade);
        void Alterar(T entidade);
        IEnumerable<T> Listar();
        T Consultar(int id);
    }
}