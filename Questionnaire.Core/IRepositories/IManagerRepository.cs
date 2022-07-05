using Questionnaire.Core.IRepositories.Base;
using Questionnaire.Core.Models;
using System.Linq.Expressions;

namespace Questionnaire.Core.IRepositories
{
    public interface IManagerRepository : IBaseRepository<Manager>
    {
        Task<Manager> GetByEmailAsync(Expression<Func<Manager, bool>> predicate);
        Task<IEnumerable<Manager>> GetAllWithCompanyDetailsAsync();
    }
}
