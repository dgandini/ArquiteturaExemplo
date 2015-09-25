using ArquiteturaExemplo.Aplicacao.Interfaces;
using ArquiteturaExemplo.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Aplicacao
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {
        private readonly IServicoBase<T> _servico;

        public AppServiceBase(IServicoBase<T> servico)
        {
            _servico = servico;
        }

        public void Incluir(T entidade)
        {
            _servico.Incluir(entidade);
        }

        public void Excluir(T entidade)
        {
            _servico.Excluir(entidade);
        }

        public void Alterar(T entidade)
        {
            _servico.Alterar(entidade);
        }

        public IEnumerable<T> Listar()
        {
            return _servico.Listar();
        }

        public T Consultar(int id)
        {
            return _servico.Consultar(id);
        }

        public void Dispose()
        {
            _servico.Dispose();
        }
    }
}
