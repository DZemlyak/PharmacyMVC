using System;
using System.Linq;
using System.Text.RegularExpressions;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;

namespace Pharmacy.BusinesLogic.Validators
{
    public class MedcineValidator : IValidator<Medcine>
    {
        private readonly IRepository<Medcine> _repository; 

        public MedcineValidator(IRepository<Medcine> repository) {
            _repository = repository;
        }

        public bool IsValid(Medcine entity) {
            var validity = !String.IsNullOrEmpty(entity.Name)
                && Regex.IsMatch(entity.SerialNumber, @"...-...-..")
                && entity.Price > 0;

            foreach (var medcine in _repository.GetAll().ToList())
            {
                if (!validity) break;
                if ((medcine.SerialNumber == entity.SerialNumber
                    || medcine.Name == entity.Name)
                    && medcine.Id != entity.Id)
                    validity = false;
            }
            return validity;
        }

        public bool IsExists(object[] key) {
            return _repository.GetByPrimaryKey(key) != null;

        }
    }
}
