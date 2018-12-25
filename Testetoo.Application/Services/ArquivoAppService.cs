using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Testetoo.Application.Interfaces;
using Testetoo.Application.ViewModels.Arquivo;
using Testetoo.Domain.Interfaces;
using Testetoo.Domain.Models;
using Testetoo.Domain.ValueObjects;

namespace Testetoo.Application.Services
{
    public class ArquivoAppService : IArquivoAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IArquivoRepository _repository;

        public ArquivoAppService(IMapper mapper, IUnitOfWork unitOfWork, IArquivoRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = _repository.GetAll().Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<ArquivoViewModel> GetAll()
        {
            OperationResultListVo<ArquivoViewModel> result;

            try
            {
                IQueryable<Arquivo> allModels = _repository.GetAll();

                IEnumerable<ArquivoViewModel> vms = _mapper.Map<IEnumerable<Arquivo>, IEnumerable<ArquivoViewModel>>(allModels);

                result = new OperationResultListVo<ArquivoViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<ArquivoViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<ArquivoViewModel> GetById(Guid id)
        {
            OperationResultVo<ArquivoViewModel> result;

            try
            {
                Arquivo model = _repository.GetById(id);

                ArquivoViewModel vm = _mapper.Map<ArquivoViewModel>(model);

                result = new OperationResultVo<ArquivoViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<ArquivoViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                _repository.Remove(id);

                _unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Add(ArquivoViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                Arquivo model;

                // TODO validate before

                Arquivo existing = _repository.GetById(viewModel.Id);
                if (viewModel.Id != Guid.Empty && existing != null)
                {
                    return new OperationResultVo<Guid>("Erro ao adicionar Arquivo");
                }

                model = _mapper.Map<Arquivo>(viewModel);

                _repository.Add(model);
                viewModel.Id = model.Id;

                _unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }
        public OperationResultVo<Guid> Update(ArquivoViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                Arquivo model;

                // TODO validate before

                Arquivo existing = _repository.GetById(viewModel.Id);
                if (viewModel.Id == Guid.Empty || existing == null)
                {
                    return new OperationResultVo<Guid>("Erro ao atualizar Arquivo");
                }

                model = _mapper.Map(viewModel, existing);

                _repository.Update(model);

                _unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }
        

        public OperationResultListVo<ArquivoListaItemViewModel> ListAll()
        {
            OperationResultListVo<ArquivoListaItemViewModel> result;

            try
            {
                IQueryable<Arquivo> allModels = _repository.GetAll();

                IEnumerable<ArquivoListaItemViewModel> vms = _mapper.Map<IEnumerable<Arquivo>, IEnumerable<ArquivoListaItemViewModel>>(allModels);

                result = new OperationResultListVo<ArquivoListaItemViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<ArquivoListaItemViewModel>(ex.Message);
            }

            return result;
        }
    }
}
