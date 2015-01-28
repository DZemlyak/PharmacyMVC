using Pharmacy.Contracts.Entities;

namespace Pharmacy.Contracts.Validator
{
    public interface IValidator<in T> where T : class, IDbEntity
    {
        bool IsValid(T entity);
        bool IsExists(params object[] key);
    }
}
