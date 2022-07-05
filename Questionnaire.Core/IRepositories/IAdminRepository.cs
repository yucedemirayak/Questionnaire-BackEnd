using Questionnaire.Core.IRepositories.Base;
using Questionnaire.Core.Models;
using System.Linq.Expressions;

namespace Questionnaire.Core.IRepositories
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<Admin> GetByEmailAsync(Expression<Func<Admin, bool>> predicate);
    }
}
