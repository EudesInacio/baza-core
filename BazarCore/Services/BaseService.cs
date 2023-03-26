using BazarCore.Data.Context;
using BazarCore.Data.Repository.Interfaces;
using BazarCore.Services.Interfaces;
using FluentValidation;
using System.Linq.Expressions;
using System.Net;

namespace BazarCore.Services
{
    public class BaseService<TEntity, TValidador> : IBaseService<TEntity>
        where TEntity : class, IEntity
        where TValidador : AbstractValidator<TEntity>
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly TValidador _validator;

        public BaseService(IRepository<TEntity> repository, TValidador validador)
        {
            _repository = repository;
            _validator = validador;
        }

        public async Task<ResultService<IEnumerable<TEntity>>> GetAllAsync()
        {
            var result = new ResultService<IEnumerable<TEntity>>();

            try
            {
                var entities = await _repository.GetAllAsync();
                result.Data = entities;
                result.Success = true;
                result.Status = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Errors = new List<string> { ex.Message };
                result.Success = false;
                result.Status = HttpStatusCode.InternalServerError;
            }

            return result;
        }

        public async Task<ResultService<TEntity>> GetByIdAsync(int id)
        {
            var result = new ResultService<TEntity>();

            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                {
                    result.Errors = new List<string> { $"Entity with ID {id} not found" };
                    result.Success = false;
                    result.Status = HttpStatusCode.NotFound;
                }
                else
                {
                    result.Data = entity;
                    result.Success = true;
                    result.Status = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                result.Errors = new List<string> { ex.Message };
                result.Success = false;
                result.Status = HttpStatusCode.InternalServerError;
            }

            return result;
        }

        public async Task<ResultService<TEntity>> AddAsync(TEntity entity)
        {
            var result = new ResultService<TEntity>();

            try
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (validationResult.IsValid)
                {
                    var addedEntity = await _repository.AddAsync(entity);
                    result.Data = addedEntity;
                    result.Success = true;
                    result.Status = HttpStatusCode.Created;
                }
                else
                {
                    result.Errors = validationResult.Errors.Select(x => x.ErrorMessage);
                    result.Success = false;
                    result.Status = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                result.Errors = new List<string> { ex.Message };
                result.Success = false;
                result.Status = HttpStatusCode.InternalServerError;
            }

            return result;
        }

        public async Task<ResultService<TEntity>> UpdateAsync(TEntity entity)
        {
            var result = new ResultService<TEntity>();

            try
            {
                var validationResult = await _validator.ValidateAsync(entity);
                if (validationResult.IsValid)
                {
                    var updatedEntity = await _repository.UpdateAsync(entity);
                    result.Data = updatedEntity;
                    result.Success = true;
                    result.Status = HttpStatusCode.OK;
                }
                else
                {
                    result.Errors = validationResult.Errors.Select(x => x.ErrorMessage);
                    result.Success = false;
                    result.Status = HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                result.Errors = new List<string> { ex.Message };
                result.Success = false;
                result.Status = HttpStatusCode.InternalServerError;
            }

            return result;
        }

        public async Task<ResultService<TEntity>> DeleteAsync(int id)
        {
            var resultService = new ResultService<TEntity>();
            try
            {
                TEntity entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    resultService.Fail(new List<string> { $"Id {id} was not found" }, HttpStatusCode.NotFound);
                await _repository.DeleteAsync(entity);
                return resultService.Good(entity);
            }
            catch (Exception ex)
            {

                return resultService.Fail(new List<string> { ex.Message }, HttpStatusCode.InternalServerError);
            }
        }
        public async Task<ResultService<TEntity>> SoftDeleteAsync(int id)
        {
            var result = new ResultService<TEntity>();

            try
            {
                TEntity entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    result.Fail($"Id {id} was not found", HttpStatusCode.NotFound);
                await _repository.SoftDeleteAsync(entity);
                return result.Good(entity);
            }
            catch (Exception ex)
            {

                return result.Fail(new List<string> { ex.Message }, HttpStatusCode.InternalServerError);
            }
        }
    }

}
