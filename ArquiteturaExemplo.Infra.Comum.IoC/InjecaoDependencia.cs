using ArquiteturaExemplo.Dominio.Interfaces.Repositorios;
using ArquiteturaExemplo.Infra.Dados.Repositorios;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaExemplo.Infra.Comum.IoC
{
    public static class InjecaoDependencia
    {
        public static void Resolve(UnityContainer container)
        {

            // Mapeamento padrão para todas as interfaces e implementações
            // que seguem o padrão INomeConcreto/NomeConcreto
            container.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Transient);

            // Entidades que não possuem o mesmo nome da interface apenas acrescentando o I como prefixo
            // Ex.: PedidoRepositoryEf implementa a interface IPedidoRepository
            container.RegisterType<IPedidoRepository, PedidoRepositoryEf>();
            container.RegisterType<IItemPedidoRepository, ItemPedidoRepositoryEf>();

           
        }
    }
}
