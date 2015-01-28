using System;
using System.Linq;
using System.Linq.Expressions;
using Pharmacy.Contracts.Entities;
using Pharmacy.Contracts.Manager;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;

namespace Pharmacy.BusinesLogic.Manager
{
    public class Manager<T>:IManager<T> where T : class, IDbEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IValidator<T> _validator; 

        public Manager(IRepository<T> repository, IValidator<T> validator) {
            _repository = repository;
            _validator = validator;
        }

        public void Add(T entity) {
            if (!_validator.IsValid(entity)) 
                throw new Exception("Entity is not valid.");
            _repository.Add(entity);
            _repository.SaveChanges();
        }

        public void Update(T entity) {
            if (!_validator.IsValid(entity))
                throw new Exception("Entity is not valid.");
            _repository.SaveChanges();
        }

        public void Remove(params object[] keys) {
            if (!_validator.IsExists(keys))
                throw new Exception("Entity doesn't exist.");
            var entity = _repository.GetByPrimaryKey(keys);
            _repository.Remove(entity);
            _repository.SaveChanges();
        }

        public T GetByPrimaryKey(params object[] keys) {
            return !_validator.IsExists(keys) ? null : _repository.GetByPrimaryKey(keys);
        }

        public IQueryable<T> GetAll() {
            return _repository.GetAll();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> expression) {
            return _repository.Find(expression);
        }
    }
}
