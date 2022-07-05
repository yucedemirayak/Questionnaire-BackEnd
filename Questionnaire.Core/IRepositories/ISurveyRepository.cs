using Questionnaire.Core.IRepositories.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IRepositories
{
    public interface ISurveyRepository : IBaseRepository<Survey>
    {
        Task<IEnumerable<Survey>> GetAllWithOptionsAsync();
    }
}
