using ArquiteturaExemplo.Apresentacao.Web.ViewModels;
using ArquiteturaExemplo.Dominio.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArquiteturaExemplo.Apresentacao.Web.Mappers
{
    public class ViewModelParaDominioProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelParaDominioProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PedidoViewModel, Pedido>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }

    }
}