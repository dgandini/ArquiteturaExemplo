using ArquiteturaExemplo.Dominio.Interfaces.Repositorios;
using ArquiteturaExemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Dominio.Servicos
{
    public class ServicoBase<T> : IServicoBase<T>, IDisposable where T : class
    {
        private readonly IRepositorioBase<T> _repositorio;

        public ServicoBase(IRepositorioBase<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Incluir(T entidade)
        {
            _repositorio.Incluir(entidade);
        }

        public virtual void Excluir(T entidade)
        {
            _repositorio.Excluir(entidade);
        }

        public void Alterar(T entidade)
        {
            _repositorio.Alterar(entidade);
        }

        public IEnumerable<T> Listar()
        {
            return _repositorio.Listar();
        }

        public T Consultar(int id)
        {
            return _repositorio.Consultar(id);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }
    }
}
