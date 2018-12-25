using AutoMapper;
using Testetoo.Application.ViewModels.Arquivo;
using Testetoo.Application.ViewModels.Usuario;

namespace Testetoo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Domain.Models.Usuario>();
            CreateMap<ArquivoViewModel, Domain.Models.Arquivo>();
        }
    }
}
