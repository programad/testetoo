using Testetoo.Application.ViewModels.Arquivo;
using Testetoo.Domain.ValueObjects;

namespace Testetoo.Application.Interfaces
{
    public interface IArquivoAppService : ICrudAppService<ArquivoViewModel>
    {
        OperationResultListVo<ArquivoListaItemViewModel> ListAll();
    }
}
