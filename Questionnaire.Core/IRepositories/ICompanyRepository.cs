using Questionnaire.Core.IRepositories.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IRepositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task<IEnumerable<Company>> GetAllWithDetailsAsync();
    }
}
