using ArquiteturaExemplo.Dominio.Interfaces.Repositorios;
using ArquiteturaExemplo.Infra.Dados.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Dados.Repositorios
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        protected ArquiteturaExemploDbContext dbContext = new ArquiteturaExemploDbContext();

        // Não usa o conceito de Unity Of Work e portanto cada entidade é salva 
        // após suas inclusão, alteração e etc... para usar UOW é preciso criar o método Salvar
        // que chama o SaveChanges() quando solicitado

        public void Incluir(T entidade)
        {
            dbContext.Set<T>().Add(entidade);
            dbContext.SaveChanges();
        }

        public void Excluir(T entidade)
        {
            dbContext.Set<T>().Remove(entidade);
            dbContext.SaveChanges();
        }

        public void Alterar(T entidade)
        {
            dbContext.Entry(entidade).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public IEnumerable<T> Listar()
        {
            return dbContext.Set<T>().ToList();
        }

        public T Consultar(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
