using System.Linq;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;

namespace Pharmacy.BusinesLogic.Validators
{
    public class StorageValidator : IValidator<Storage>
    {
        private readonly IRepository<Storage> _repository;
        private readonly IValidator<Medcine> _medcineValidator;
        private readonly IValidator<Core.Pharmacy> _pharmacyValidator; 

        public StorageValidator(IRepository<Storage> repository, 
            IValidator<Medcine> medcineValidator, 
            IValidator<Core.Pharmacy> pharmacyValidator)
        {
            _repository = repository;
            _medcineValidator = medcineValidator;
            _pharmacyValidator = pharmacyValidator;
        }

        public bool IsValid(Storage entity)
        {
            return _medcineValidator.IsExists(entity.MedcineId)
                   && _pharmacyValidator.IsExists(entity.PharmacyId)
                   && IsExists(entity.MedcineId, entity.PharmacyId)
                   && (_repository.Find(t => t.MedcineId == entity.MedcineId 
                                             && t.PharmacyId == entity.PharmacyId) != null);
        }

        public bool IsExists(params object[] keys) {
            if (keys.Length != 2)
                return false;
            return _repository.GetByPrimaryKey(keys) != null;
        }
    }
}
