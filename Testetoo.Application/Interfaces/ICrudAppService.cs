using System;
using System.Collections.Generic;
using System.Text;
using Testetoo.Domain.ValueObjects;

namespace Testetoo.Application.Interfaces
{
    public interface ICrudAppService<T>
    {
        OperationResultVo<int> Count();
        OperationResultListVo<T> GetAll();
        OperationResultVo<T> GetById(Guid id);
        OperationResultVo<Guid> Add(T viewModel);
        OperationResultVo<Guid> Update(T viewModel);
        OperationResultVo Remove(Guid id);
    }
}
