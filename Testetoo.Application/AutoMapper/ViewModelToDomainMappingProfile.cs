using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Application.ViewModels.Usuario;

namespace Testetoo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Domain.Models.Usuario>();
        }
    }
}
