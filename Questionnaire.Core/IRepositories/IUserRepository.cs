using Questionnaire.Core.IRepositories.Base;
using Questionnaire.Core.Models;
using System.Linq.Expressions;

namespace Questionnaire.Core.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetAllWithCompanyDetailsAsync();
    }
}
