using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;

namespace Pharmacy.BusinesLogic.Validators
{
    public class OrderDetailsValidator : IValidator<OrderDetails>
    {
        private readonly IRepository<OrderDetails> _repository;
        private readonly IValidator<Order> _orderValidator;
        private readonly IValidator<Medcine> _medcineValidator; 

        public OrderDetailsValidator(IRepository<OrderDetails> repository, 
            IValidator<Order> orderValidator, 
            IValidator<Medcine> medcineValidator)
        {
            _repository = repository;
            _orderValidator = orderValidator;
            _medcineValidator = medcineValidator;
        }

        public bool IsValid(OrderDetails entity)
        {
            if (!IsExists(entity.OrderId, entity.MedcineId)
                && entity.Medcine == null && entity.Order == null
                && entity.UnitPrice > 0 && entity.Count > 0)
                return true;
            return IsExists(entity.OrderId, entity.MedcineId)
                   && entity.Medcine != null && entity.Order != null
                   && entity.UnitPrice > 0 && entity.Count > 0;
        }

        public bool IsExists(params object[] key) {
            return _repository.GetByPrimaryKey(key) != null;
        }
    }
}
