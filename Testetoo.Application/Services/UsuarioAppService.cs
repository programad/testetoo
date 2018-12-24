using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Testetoo.Application.Interfaces;
using Testetoo.Application.ViewModels.Usuario;
using Testetoo.Domain.Interfaces;
using Testetoo.Domain.Models;
using Testetoo.Domain.ValueObjects;

namespace Testetoo.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;

        public UsuarioAppService(IMapper mapper, IUnitOfWork unitOfWork, IUsuarioRepository repository)
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

        public OperationResultListVo<UsuarioViewModel> GetAll()
        {
            OperationResultListVo<UsuarioViewModel> result;

            try
            {
                IQueryable<Usuario> allModels = _repository.GetAll();

                IEnumerable<UsuarioViewModel> vms = _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(allModels);

                result = new OperationResultListVo<UsuarioViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UsuarioViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UsuarioViewModel> GetById(Guid id)
        {
            OperationResultVo<UsuarioViewModel> result;

            try
            {
                Usuario model = _repository.GetById(id);

                UsuarioViewModel vm = _mapper.Map<UsuarioViewModel>(model);

                result = new OperationResultVo<UsuarioViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<UsuarioViewModel>(ex.Message);
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

        public OperationResultVo<Guid> Add(UsuarioViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                Usuario model;

                // TODO validate before

                Usuario existing = _repository.GetById(viewModel.Id);
                if (viewModel.Id != Guid.Empty && existing != null)
                {
                    return new OperationResultVo<Guid>("Erro ao adicionar Usuário");
                }

                model = _mapper.Map<Usuario>(viewModel);

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
        public OperationResultVo<Guid> Update(UsuarioViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                Usuario model;

                // TODO validate before

                Usuario existing = _repository.GetById(viewModel.Id);
                if (viewModel.Id == Guid.Empty || existing == null)
                {
                    return new OperationResultVo<Guid>("Erro ao atualizar Usuário");
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
    }
}
