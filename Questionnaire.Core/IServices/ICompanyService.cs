using Questionnaire.Core.IServices.Base;
using Questionnaire.Core.Models;

namespace Questionnaire.Core.IServices
{
    public interface ICompanyService : IBaseService<Company>
    {
        Task<IEnumerable<Company>> ReceiveAllWithDetails();
    }
}
