using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Application.ViewModels.Usuario;
using Testetoo.Domain.Models;

namespace Testetoo.Application.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
