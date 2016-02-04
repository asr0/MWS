using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MWS.Aplicacao;
using MWS.Dominio.Repository;
using MWS.Dominio.Services;
using MWS.Infraestrutura.ORM;
using MWS.Infraestrutura.ORM.DataContexts;
using MWS.Infraestrutura.Repositorios;
using MWS.NucleoCompartilhado;
using MWS.NucleoCompartilhado.Eventos.Contratos;

namespace MWS.CrossCutting
{
    class DependencyRegister
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<StoreDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork,UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository,UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoriaRepository,CategoriaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPedidoRepository,PedidoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProdutoRepository,ProdutoRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUsuarioApplicationService,UsuarioApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoriaApplicationService,CategoriaApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IPedidoApplicationService,PedidoApplicationService>(new HierarchicalLifetimeManager());
            container.RegisterType<IProdutoApplicationService, ProdutoApplicationService>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<NotificacaoDominio>,NotificacaoDominioHandler>(new HierarchicalLifetimeManager());

        }
    }
}
