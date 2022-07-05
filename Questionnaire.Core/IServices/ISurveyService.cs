using Questionnaire.Core.IServices.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IServices
{
    public interface ISurveyService : IBaseService<Survey>
    {
        Task<IEnumerable<Survey>> ReceiveAllWithOptions();
    }
}
