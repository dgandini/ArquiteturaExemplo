using ArquiteturaExemplo.Apresentacao.Web.ViewModels;
using ArquiteturaExemplo.Dominio.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArquiteturaExemplo.Apresentacao.Web.Mappers
{
    public class DominioParaViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DominioParaViewModelProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Pedido, PedidoViewModel>();
        }
    }
}