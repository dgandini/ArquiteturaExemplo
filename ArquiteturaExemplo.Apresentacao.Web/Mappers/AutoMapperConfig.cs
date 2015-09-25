using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArquiteturaExemplo.Apresentacao.Web.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegistrarMapeamentos()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DominioParaViewModelProfile>();
                x.AddProfile<ViewModelParaDominioProfile>();
            });
        }
    }
}